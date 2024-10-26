

namespace KXStoreSystem.Front.Models.Responses
{
    public class SaleResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Domain.Models.Entities.Customer Customer { get; set; }
        public required string ProductName { get; set; }
        public DateTime Date { get; set; }
        public required decimal TotalValue { get; set; }
    }
}
