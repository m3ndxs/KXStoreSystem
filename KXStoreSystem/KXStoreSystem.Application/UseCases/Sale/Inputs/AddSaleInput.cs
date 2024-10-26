namespace KXStoreSystem.Application.UseCases.Sale.Inputs
{
    public class AddSaleInput
    {
        public int CustomerId { get; set; }
        public required string ProductName { get; set; }
        public DateTime Date { get; set; }
        public required decimal TotalValue { get; set; }
    }
}