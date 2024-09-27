using TradingMicroservice.Models;

namespace Medirect_Assesment.Services
{
    public interface ITradingService
    {
        Task<Trade> ExecuteTradeAsync(Trade trade);
        Task<Trade> GetTradeAsync(Guid id);
        Task<IEnumerable<Trade>> GetAllTradesAsync();
    }
}