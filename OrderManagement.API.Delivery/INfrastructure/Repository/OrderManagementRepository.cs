using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Delivery.DTO.InternalAPIModel.Request;
using OrderManagement.API.Delivery.DTO.InternalAPIModel.Response;
using OrderManagement.API.Delivery.INfrastructure.Configuration;
using OrderManagement.API.Delivery.INfrastructure.Entities;

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

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var ordersData = await _dbContext.Orders
                .Select(o => new OrderResponse
                {
                    Id = o.Id,
                    Description = o.Description
                })
                .ToListAsync();

            return ordersData;
        }

        public async Task<OrderResponse> AddOrderAsync(OrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                throw new ArgumentNullException(nameof(orderRequest));
            }

            var newOrder = new Order
            {
                Description = orderRequest.Description,
                TotalAmount = orderRequest.TotalAmount,
                CustomerId = orderRequest.CustomerId
            };

            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();

            var orderResponse = new OrderResponse
            {
                Id = newOrder.Id,
                Description = newOrder.Description
            };

            return orderResponse;
        }

        public async Task<OrderResponse> UpdateOrderAsync(OrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                throw new ArgumentNullException(nameof(orderRequest));
            }

            var existingOrder = await _dbContext.Orders.FindAsync(orderRequest.Id);

            if (existingOrder == null)
            {
                return null; // یک پاسخ خاص برای حالت عدم یافتن سفارش
            }

            existingOrder.Description = orderRequest.Description;
            existingOrder.TotalAmount = orderRequest.TotalAmount;

            await _dbContext.SaveChangesAsync();

            var orderResponse = new OrderResponse
            {
                Id = existingOrder.Id,
                Description = existingOrder.Description
            };

            return orderResponse;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var orderToDelete = await _dbContext.Orders.FindAsync(orderId);

            if (orderToDelete == null)
            {
                return false; 
            }

            _dbContext.Orders.Remove(orderToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}