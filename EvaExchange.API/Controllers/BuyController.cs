using EvaExchange.Services;
using EvaExchange.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        ITransactionService _transactionService;
        public BuyController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Buy(TradeModel tradeReq)
        {
            if (ModelState.IsValid)
            {
                var tradeIsSucces = await _transactionService.Buy(tradeReq);
                return Ok(new { message = $"tebrikler, aldınız!" });
            }
            return BadRequest(ModelState);
        }
    }
}
