namespace Medirect_Assesment.Models
{

        public class Trade
        {
            public Guid Id { get; set; }
            public string Symbol { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }