namespace KXStoreSystem.Front.Models.Responses
{
    public class AddSaleResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Domain.Models.Entities.Customer Customer { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
    }
}
