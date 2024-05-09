using Microsoft.EntityFrameworkCore;
using VehiclesApi.Data;
using VehiclesApi.Interfaces;
using VehiclesApi.Models;

namespace VehiclesApi.Services
{
    public class VehicleService : IVehicle
    {
        private ApiDbContext _dbContext;

        public VehicleService()
        {
            _dbContext = new ApiDbContext();
        }
        public async Task AddVehicle(Vehicle vehicle)
        {
            await _dbContext.Vehicles.AddAsync(vehicle);
            _dbContext.SaveChanges();


        }

        public async Task DeleteVehicle(int id)
        {
            var vehicle = await _dbContext.Vehicles.FindAsync(id);
            _dbContext.Vehicles.Remove(vehicle);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {

            return await _dbContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
           return await _dbContext.Vehicles.FindAsync(id);
        }

        public async Task UpdateVehicle(int id, Vehicle vehicle)
        {
           var vehicleObj = await _dbContext.Vehicles.FindAsync(id);
            if (vehicleObj != null)
            {
                vehicleObj.Price= vehicle.Price;
                vehicleObj.Displacement= vehicle.Displacement;
                vehicleObj.Height= vehicle.Height;
                vehicleObj.Width= vehicle.Width;
                vehicleObj.ImageUrl= vehicle.ImageUrl;
                vehicleObj.Name= vehicle.Name;
                vehicleObj.MaxSpeed = vehicle.MaxSpeed;

                await _dbContext.SaveChangesAsync();
            }


        }
    }
}
