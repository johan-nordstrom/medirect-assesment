using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medirect_Assesment.Models;

namespace Medirect_Assesment.Services
{
    public class TradingService : ITradingService
    {
        private readonly Dictionary<Guid, Trade> _trades = new Dictionary<Guid, Trade>();
        private readonly IMessageQueueService _messageQueueService;

        public TradingService(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService;
        }

        public async Task<Trade> ExecuteTradeAsync(Trade trade)
        {
            trade.Id = Guid.NewGuid();
            trade.Timestamp = DateTime.UtcNow;
            _trades[trade.Id] = trade;

            await _messageQueueService.PublishTradeMessageAsync(trade);

            return trade;
        }

        public Task<Trade> GetTradeAsync(Guid id)
        {
            _trades.TryGetValue(id, out var trade);
            return Task.FromResult(trade);
        }

        public Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            return Task.FromResult<IEnumerable<Trade>>(_trades.Values);
        }
    }
}