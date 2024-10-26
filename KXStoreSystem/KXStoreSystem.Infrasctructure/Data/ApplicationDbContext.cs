using KXStoreSystem.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KXStoreSystem.Infrasctructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
