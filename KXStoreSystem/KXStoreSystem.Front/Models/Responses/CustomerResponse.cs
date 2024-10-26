namespace KXStoreSystem.Front.Models.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
