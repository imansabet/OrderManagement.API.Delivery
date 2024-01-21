using OrderManagement.API.Delivery.DTO.ExternalApiModel.Request;
using OrderManagement.API.Delivery.DTO.ExternalApiModel.Response;

namespace OrderManagement.API.Delivery.INfrastructure.Repository
{
    public interface IOrderManagementRepository 
    {
        Task<OrderResponse> GetOrderByCustomerIdAsync(CustomerIdRequest customerIdRequest);

    }
}
