using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using VehiclesApi.Extension;
using VehiclesApi.Interfaces;
using VehiclesApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehiclesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicle _vehicleService;
        public VehiclesController(IVehicle vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {

            return await _vehicleService.GetAllVehicles();
        }

        [HttpGet("{id}")]
        public async Task<Vehicle> Get(int id)
        {


            return await _vehicleService.GetVehicleById(id);
        }

        [HttpPost]
        public async Task<Vehicle> Post(Vehicle request)
        {

            await _vehicleService.AddVehicle(request);

            return request;
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleService.UpdateVehicle(id, vehicle);

        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }


    }
}
