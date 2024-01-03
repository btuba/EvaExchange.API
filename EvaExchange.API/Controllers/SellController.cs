using EvaExchange.Services;
using EvaExchange.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace EvaExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        ITransactionService _transactionService;
        public SellController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Sell(TradeModel tradeReq)
        {
            if (ModelState.IsValid)
            {
                var tradeIsSucces = await _transactionService.Sell(tradeReq);
                return Ok(new { message = $"tebrikler, sattınız!" });
            }
            return BadRequest(ModelState);
        }
    }
}
