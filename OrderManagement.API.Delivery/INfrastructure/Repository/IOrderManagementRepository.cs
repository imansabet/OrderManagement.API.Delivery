using OrderManagement.API.Delivery.DTO.InternalAPIModel.Request;
using OrderManagement.API.Delivery.DTO.InternalAPIModel.Response;

namespace OrderManagement.API.Delivery.INfrastructure.Repository
{
    public interface IOrderManagementRepository 
    {
        Task<OrderResponse> GetOrderByCustomerIdAsync(CustomerIdRequest customerIdRequest);

    }
}
