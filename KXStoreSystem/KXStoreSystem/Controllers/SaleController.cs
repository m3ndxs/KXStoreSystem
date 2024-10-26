using KXStoreSystem.Application.UseCases.Sale;
using KXStoreSystem.Application.UseCases.Sale.Inputs;
using Microsoft.AspNetCore.Mvc;

namespace KXStoreSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly ISaleUseCase _saleUseCase;

        public SaleController(ISaleUseCase saleUseCase)
        {
            _saleUseCase = saleUseCase;
        }

        [HttpGet]
        public IActionResult GetAllSales() 
        { 
            return Ok(_saleUseCase.GetAll());
        }

        [HttpGet("list-by-customer/{customerId:int}")]
        public IActionResult GetSalesByCustomer(int customerId)
        {
            return Ok(_saleUseCase.GetByCustomerId(customerId));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSalesById(int id) 
        {
            var sale = _saleUseCase.Get(id);

            if (sale is null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        [HttpPost]
        public IActionResult AddSale(AddSaleInput input)
        {
            try
            {
                return Ok(_saleUseCase.Post(input));
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateSale(int id, UpdateSaleInput input)
        {
            return Ok(_saleUseCase.Put(id, input));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteSale(int id)
        {
            return Ok(_saleUseCase.Delete(id));
        }
    }
}
