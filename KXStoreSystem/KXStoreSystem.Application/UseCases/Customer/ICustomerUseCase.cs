using KXStoreSystem.Application.UseCases.Customer.Inputs;

namespace KXStoreSystem.Application.UseCases.Customer
{
    public interface ICustomerUseCase
    {
        bool Delete(int id);
        Domain.Models.Entities.Customer Get(int id);
        List<Domain.Models.Entities.Customer> GetAll();
        Domain.Models.Entities.Customer Post(AddCustomerInput input);
        Domain.Models.Entities.Customer Put(int id, UpdateCustomerInput input);
    }
}
