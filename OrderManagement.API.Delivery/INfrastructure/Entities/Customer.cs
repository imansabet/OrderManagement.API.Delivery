namespace OrderManagement.API.Delivery.INfrastructure.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }  
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }  

        // Navigation Property
        public List<Order> Orders { get; set; }
    }
}
