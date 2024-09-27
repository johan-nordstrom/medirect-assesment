// TradingMicroservice/Services/IMessageQueueService.cs
using System.Threading.Tasks;
using TradingMicroservice.Models;

namespace Medirect_Assesment.Services
{
    public interface IMessageQueueService
    {
        Task PublishTradeMessageAsync(Trade trade);
    }
} 