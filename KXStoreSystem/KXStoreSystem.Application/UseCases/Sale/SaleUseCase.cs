using KXStoreSystem.Application.UseCases.Sale.Inputs;
using KXStoreSystem.Domain.Models.Entities;
using KXStoreSystem.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KXStoreSystem.Application.UseCases.Sale
{
    public class SaleUseCase : ISaleUseCase
    {
        private readonly ApplicationDbContext _dbContext;

        public SaleUseCase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Domain.Models.Entities.Sale Get(int id)
        {
            var sale = _dbContext.Sales.Find(id);

            sale.Customer = GetCustomer(sale.CustomerId);

            return sale;
        }

        public List<Domain.Models.Entities.Sale> GetAll()
        { 
            var sales = _dbContext.Sales.ToList();

            foreach (var sale in sales) 
            {
                sale.Customer = GetCustomer(sale.CustomerId);
            }

            return sales;
        }

        public List<Domain.Models.Entities.Sale> GetByCustomerId(int customerId)
        {
            var sales = _dbContext.Sales.Where(x => x.CustomerId == customerId).ToList();

            foreach (var sale in sales)
            {
                sale.Customer = GetCustomer(sale.CustomerId);
            }

            return sales;
        }

        public Domain.Models.Entities.Sale Post(AddSaleInput input)
        {
            var existingCustomer = _dbContext.Customers.FirstOrDefault(option => option.Id == input.CustomerId);

            if (existingCustomer == null) {
                throw new InvalidOperationException("Cliente não encontrado.");
            }

            var saleEntity = new Domain.Models.Entities.Sale()
            {
                ProductName = input.ProductName,
                TotalValue = input.TotalValue,
                CustomerId = input.CustomerId,
                Date = input.Date
            };

            var result = _dbContext.Sales.Add(saleEntity);
            _dbContext.SaveChanges();

            return result.Entity;

        }

        public Domain.Models.Entities.Sale Put(int id, UpdateSaleInput input)
        {
            var sale = _dbContext.Sales.Find(id);

            sale.ProductName = input.ProductName;
            sale.TotalValue = input.TotalValue;
            sale.CustomerId = input.CustomerId;
            sale.Date = input.Date;

            _dbContext.SaveChanges();

            return sale;
        }

        public bool Delete(int id)
        {
            var sale = _dbContext.Sales.Find(id);

            _dbContext.Sales.Remove(sale);

            var result = _dbContext.SaveChanges();

            return result == 1;
        }

        private Domain.Models.Entities.Customer GetCustomer(int customerId)
        {
            return _dbContext.Customers.Find(customerId);
        }
    }
}
