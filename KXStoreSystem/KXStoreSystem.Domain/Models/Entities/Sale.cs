using System.Globalization;

namespace KXStoreSystem.Domain.Models.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public required string ProductName { get; set; }
        public DateTime Date { get; set; }
        public required decimal TotalValue { get; set; }
    }
}
