namespace OrderManagement.API.Delivery.DTO.InternalAPIModel.Request
{
    public class OrderRequest
    {
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
    }
}
