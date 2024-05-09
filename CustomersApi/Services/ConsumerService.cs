using Azure.Messaging.ServiceBus;
using CustomersApi.Data;
using CustomersApi.Interfaces;
using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CustomersApi.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IConfiguration _configuration;

        //private readonly ConsumerDbContext _consumerDbContext;

        //public ConsumerService(ConsumerDbContext consumerDbContext)
        //{
        //    _consumerDbContext = consumerDbContext;
        //}

        private ConsumerDbContext _dbContext;
        public ConsumerService(IConfiguration configuration)
        {
            _dbContext = new ConsumerDbContext();
            _configuration = configuration;
        }

        public async Task AddCustomer(Consumer consumer)
        {
            var vehicleInDb = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == consumer.VehicleId);
            if (vehicleInDb == null)
            {
                await _dbContext.Vehicles.AddAsync(consumer.Vehicle);
                await _dbContext.SaveChangesAsync();
            }
            consumer.Vehicle = null;
            await _dbContext.Consumers.AddAsync(consumer);
            await _dbContext.SaveChangesAsync();


            // Add code for Azure messaging bus

            string connectionString = _configuration["AppSettings:ServiceBusConnection"];
            string queueName = _configuration["AppSettings:ServiceBusQueueName"];
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);


            var objectAsText = JsonConvert.SerializeObject(consumer);
            // create the sender
            ServiceBusSender sender = client.CreateSender(queueName);

            // create a message that we can send. UTF-8 encoding is used when providing a string.
            ServiceBusMessage message = new ServiceBusMessage(objectAsText);

            // send the message
            await sender.SendMessageAsync(message);
        }

        public Task DeleteConsumer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetAllConsumers()
        {
            throw new NotImplementedException();
        }

        public Task GetConsumer(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateConsumer(int id, Consumer consumer)
        {
            throw new NotImplementedException();
        }
    }
}
