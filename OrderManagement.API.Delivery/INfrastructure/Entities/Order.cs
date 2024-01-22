namespace OrderManagement.API.Delivery.INfrastructure.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } 
        public decimal TotalAmount { get; set; }

        // Foreign Key
        public Guid CustomerId { get; set; }

        // Navigation Property
        public Customer Customer { get; set; }
    }
}
