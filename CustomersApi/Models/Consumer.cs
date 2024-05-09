namespace CustomersApi.Models
{
    public class Consumer
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
