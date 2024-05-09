using CustomersApi.Models;

namespace CustomersApi.Interfaces
{
    public interface IConsumerService
    {
        Task AddCustomer(Consumer consumer);
        Task GetAllConsumers();
        Task GetConsumer(Consumer consumer);
        Task DeleteConsumer(int id);
        Task UpdateConsumer(int id, Consumer consumer);
    }
}
