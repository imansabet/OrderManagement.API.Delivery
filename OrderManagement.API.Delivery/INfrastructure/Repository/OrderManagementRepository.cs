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

            // اتصال به دیتابیس و بازیابی اطلاعات مرتبط با customerIdRequest
            var orderData = await _dbContext.Orders
                .Where(o => o.CustomerId == customerIdRequest.Id)
                .FirstOrDefaultAsync();

            // اگر داده‌های مورد نظر را دریافت کردید، آنها را به OrderResponse تبدیل کنید و برگردانید.
            if (orderData != null)
            {
                var orderResponse = new OrderResponse
                {
                    Id = orderData.Id,
                    Description = orderData.Description
                };

                return orderResponse;
            }

            // اگر داده‌ای یافت نشد، می‌توانید یک رفتار مورد نظر را اجرا کنید.
            // برای مثال می‌توانید یک خطای مناسب برگردانید یا یک مقدار پیش‌فرض.

            return null;
        }
    }
}
