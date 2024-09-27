using Medirect_Assesment.Models;

namespace Medirect_Assesment.Services
{
    public interface IMessageQueueService
    {
        Task PublishTradeMessageAsync(Trade trade);
    }
} 