using KXStoreSystem.Application.UseCases.Customer.Inputs;
using KXStoreSystem.Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KXStoreSystem.Application.UseCases.Customer
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerUseCase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Domain.Models.Entities.Customer Get(int id)
        {
            return _dbContext.Customers.Find(id);
        }

        public List<Domain.Models.Entities.Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public Domain.Models.Entities.Customer Post(AddCustomerInput input)
        {
            var customerEntity = new Domain.Models.Entities.Customer()
            {
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                DateOfBirth = input.DateOfBirth
            };

            var result = _dbContext.Customers.Add(customerEntity);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Domain.Models.Entities.Customer Put(int id, UpdateCustomerInput input) 
        {
            var customer = _dbContext.Customers.Find(id);

            customer.Name = input.Name;
            customer.Email = input.Email;
            customer.Phone = input.Phone;
            customer.DateOfBirth = input.DateOfBirth;

            _dbContext.SaveChanges();

            return customer;
        }

        public bool Delete(int id) 
        {
            var customer = _dbContext.Customers.Find(id);

            _dbContext.Customers.Remove(customer);

            var result = _dbContext.SaveChanges();

            return result == 1;
        }
    }
}
