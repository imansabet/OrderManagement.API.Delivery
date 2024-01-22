namespace OrderManagement.API.Delivery.DTO.InternalAPIModel.Request
{
    public class OrderRequest
    {
        public Guid OrderId { get; set; } // تغییر نام پراپرتی به OrderId
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
