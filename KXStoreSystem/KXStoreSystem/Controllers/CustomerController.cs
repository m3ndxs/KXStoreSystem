using KXStoreSystem.Application.UseCases.Customer;
using KXStoreSystem.Application.UseCases.Customer.Inputs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KXStoreSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerUseCase _customerUseCase;

        public CustomerController(ICustomerUseCase customerUseCase)
        {
            _customerUseCase = customerUseCase;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerUseCase.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerUseCase.Get(id);

            if (customer is null)
            { 
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input)
        {
            return Ok(_customerUseCase.Post(input));
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCustomer(int id, UpdateCustomerInput input)
        {
            return Ok(_customerUseCase.Put(id, input));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            return Ok(_customerUseCase.Delete(id));
        }
    }
}
