using CustomersApi.Interfaces;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IConsumerService _consumerService;
        public CustomerController(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task Post([FromBody] Consumer consumer)
        {
            await _consumerService.AddCustomer(consumer);


        }

    }
}
