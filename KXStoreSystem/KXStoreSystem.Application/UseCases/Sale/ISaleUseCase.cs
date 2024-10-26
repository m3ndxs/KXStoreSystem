using KXStoreSystem.Application.UseCases.Sale.Inputs;

namespace KXStoreSystem.Application.UseCases.Sale
{
    public interface ISaleUseCase
    {
        bool Delete(int id);
        Domain.Models.Entities.Sale Get(int id);
        List<Domain.Models.Entities.Sale> GetAll();
        List<Domain.Models.Entities.Sale> GetByCustomerId(int customerId);
        Domain.Models.Entities.Sale Post(AddSaleInput input);
        Domain.Models.Entities.Sale Put(int id, UpdateSaleInput input);
    }
}
