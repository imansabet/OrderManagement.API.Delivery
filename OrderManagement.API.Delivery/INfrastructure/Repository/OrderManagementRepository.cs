using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Delivery.DTO.ExternalApiModel.Request;
using OrderManagement.API.Delivery.DTO.ExternalApiModel.Response;
using OrderManagement.API.Delivery.INfrastructure.Configuration;

namespace OrderManagement.API.Delivery.INfrastructure.Repository
{
    public class OrderManagementRepository : IOrderManagementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderManagementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<OrderResponse> GetOrderByCustomerIdAsync(CustomerIdRequest customerIdRequest)
        {
            if (customerIdRequest == null)
            {
                throw new ArgumentNullException(nameof(customerIdRequest));
            }

            var orderData = await _dbContext.Orders
                .Where(o => o.CustomerId == customerIdRequest.Id)
                .FirstOrDefaultAsync();

            if (orderData != null)
            {
                var orderResponse = new OrderResponse
                {
                    Id = orderData.Id,
                    Description = orderData.Description
                };

                return orderResponse;
            }


            return null;
        }
    }
}
