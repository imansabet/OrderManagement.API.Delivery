namespace OrderManagement.API.Delivery.INfrastructure.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public List<Order> Orders { get; set; }
    }
}
