using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReservationsApi.Data;
using ReservationsApi.Interfaces;
using ReservationsApi.Models;
using System.Net;
using System.Net.Mail;

namespace ReservationsApi.Services
{
    public class ReservationService : IReservation
    {
        private readonly IConfiguration _configuration;
        private ApiDbContext dbContext;
        public ReservationService(IConfiguration configuration)
        {
            dbContext = new ApiDbContext();
            _configuration = configuration;
        }
        public async Task<List<Reservation>> GetReservations()
        {


            string connectionString = _configuration["AppSettings:ServiceBusConnection"];
            string queueName = _configuration["AppSettings:ServiceBusQueueName"];
            // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            // the received message is a different type as it contains some service set properties
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(10);

            if (receivedMessages == null)
                return null;

            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string body = receivedMessage.Body.ToString();
                var messageCreated = JsonConvert.DeserializeObject<Reservation>(body);
                await dbContext.Reservations.AddAsync(messageCreated);
                await dbContext.SaveChangesAsync();
                await receiver.CompleteMessageAsync(receivedMessage);
            }

            return await dbContext.Reservations.ToListAsync();

        }

        public async Task UpdateMailStatus(int id)
        {
            string SenderEmail = "obafemi.bolaji@gmail.com";
            var reservationResult = await dbContext.Reservations.FindAsync(id);

            if(reservationResult != null && reservationResult.isMailSent == false )
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,                 
                    EnableSsl= true,
                };
                smtpClient.Credentials = new NetworkCredential(_configuration["AppSettings:SenderEmail"], _configuration["AppSettings:EmailAppKey"]);
                smtpClient.Send(SenderEmail, "obafemi.bolaji@yahoo.com", "Vehicle Test Drive", "Your test is reserved");
                reservationResult.isMailSent = true;
                await dbContext.SaveChangesAsync();
            }

        }
    }
}
