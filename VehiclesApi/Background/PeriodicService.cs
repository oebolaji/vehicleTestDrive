using VehiclesApi.Data;

namespace VehiclesApi.Background
{
    public class PeriodicService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public PeriodicService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // All code goes here

                var _dbContext = _serviceProvider.GetRequiredService<ApiDbContext>();



                await Task.Delay(new TimeSpan(1, 10, 0));
            }
        }
    }
}
