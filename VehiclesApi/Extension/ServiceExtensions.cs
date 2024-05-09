using VehiclesApi.Interfaces;
using VehiclesApi.Services;

namespace VehiclesApi.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicle, VehicleService>();
        }
    }
}
