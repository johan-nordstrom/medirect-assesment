using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medirect_Assesment.Models;
using Medirect_Assesment.Services;
using Microsoft.AspNetCore.Http;

namespace Medirect_Assesment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradesController : ControllerBase
    {
        private readonly ITradingService _tradingService;

        public TradesController(ITradingService tradingService)
        {
            _tradingService = tradingService;
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteTrade([FromBody] Trade trade)
        {
            var executedTrade = await _tradingService.ExecuteTradeAsync(trade);
            return CreatedAtAction(nameof(GetTrade), new { id = executedTrade.Id }, executedTrade);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrade(Guid id)
        {
            var trade = await _tradingService.GetTradeAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            return Ok(trade);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrades()
        {
            var trades = await _tradingService.GetAllTradesAsync();
            return Ok(trades);
        }
    }
}