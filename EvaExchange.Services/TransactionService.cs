using EvaExchange.Core;
using EvaExchange.DataAccess.Repositories;
using EvaExchange.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchange.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionWriteRepository _transactionWriteRepository;
        private readonly IShareReadRepository _shareReadRepository;
        private readonly IClientReadRepository _clientReadRepository;
        private readonly IPriceReadRepository _priceReadRepository;
        private readonly IPortfolioReadRepository _portfolioReadRepository;
        private readonly ITransactionReadRepository _transactionReadRepository;

        public TransactionService(ITransactionWriteRepository transactionWriteRepository
            , IShareReadRepository shareReadRepository, IClientReadRepository clientReadRepository
            , IPriceReadRepository priceReadRepository, IPortfolioReadRepository portfolioReadRepository
            , ITransactionReadRepository transactionReadRepository)
        {
            _transactionWriteRepository = transactionWriteRepository;
            _shareReadRepository = shareReadRepository;
            _clientReadRepository = clientReadRepository;
            _priceReadRepository = priceReadRepository;
            _portfolioReadRepository = portfolioReadRepository;
            _transactionReadRepository = transactionReadRepository;
        }

        public async Task<bool> Buy(TradeModel trade)
        {
            var isShareExist = await _shareReadRepository.IsExist(trade.ShareId);

            if (!isShareExist)
            {
                throw new Exception("Share could not be found.");
            }

            var isClientExist = await _clientReadRepository.IsExist(trade.ClientId);

            if (!isClientExist)
            {
                throw new Exception("Customer could not be found.");
            }

            var clientPortfolio = _portfolioReadRepository.GetWhere(x => x.Client.Id == trade.ClientId).FirstOrDefault();

            if (clientPortfolio == null)
            {
                throw new Exception("Customer's portfolio could not be found.");
            }

            IQueryable<Price> priceList = (IQueryable<Price>)_priceReadRepository.GetWhere(x => x.Share.Id == trade.ShareId);

            if (priceList == null)
            {
                throw new Exception("Share's price could not be found.");
            }

            Price latestPrice = priceList.OrderByDescending(x => x.CreatedDate).First();

            var share = await _shareReadRepository.GetByIdAsync(trade.ShareId);

            var transaction = new Transaction
            {
                Action = nameof(Buy),
                Portfolio = clientPortfolio,
                Share = share,
                Quantity = trade.Quentity,
                Rate = latestPrice.Rate
            };

            return await _transactionWriteRepository.AddAsync(transaction);
        }

        public async Task<bool> Sell(TradeModel trade)
        {
            var isClientExist = await _clientReadRepository.IsExist(trade.ClientId);

            if (!isClientExist)
            {
                throw new Exception("Customer does not exist.");
            }

            var clientPortfolio = _portfolioReadRepository.GetWhere(x => x.Client.Id == trade.ClientId).FirstOrDefault();

            if (clientPortfolio == null)
            {
                throw new Exception("Customer's portfolio could not be found.");
            }

            IQueryable<Transaction> clientTransactions = 
                _transactionReadRepository.GetWhere(x => x.Portfolio.Id == clientPortfolio.Id && x.Share.Id == trade.ShareId);

            var sellCount = clientTransactions.Where(x=> x.Action == "Sell").Sum(x=> x.Quantity);
            var buyCount = clientTransactions.Where(x => x.Action == "Buy").Sum(x => x.Quantity);

            if (!clientTransactions.Any())
            {
                throw new Exception("Share does not exist in the custome's portfolio.");
            }

            if ((buyCount - sellCount) - trade.Quentity < 0)
            {
                throw new Exception("Customer does not have enough shares to sell.");
            }

            IQueryable<Price> priceList = (IQueryable<Price>)_priceReadRepository.GetWhere(x => x.Share.Id == trade.ShareId);

            if (priceList == null)
            {
                throw new Exception("Share's price does not found.");
            }

            Price latestPrice = priceList.OrderByDescending(x => x.CreatedDate).First();

            var share = await _shareReadRepository.GetByIdAsync(trade.ShareId);

            var transaction = new Transaction
            {
                Action = nameof(Sell),
                Portfolio = clientPortfolio,
                Share = share,
                Quantity = trade.Quentity,
                Rate = latestPrice.Rate
            };

            return await _transactionWriteRepository.AddAsync(transaction);
        }
    }
}
