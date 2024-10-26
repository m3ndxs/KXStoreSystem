namespace KXStoreSystem.Application.UseCases.Customer.Inputs
{
    public class UpdateCustomerInput
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
