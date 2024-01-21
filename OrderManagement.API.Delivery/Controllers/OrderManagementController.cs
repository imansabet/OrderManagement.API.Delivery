using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.Delivery.DTO.ExternalApiModel.Request;
using OrderManagement.API.Delivery.DTO.ExternalApiModel.Response;
using OrderManagement.API.Delivery.INfrastructure.Repository;

namespace OrderManagement.API.Delivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManagementRepository _orderManagementRepository;

        public OrderController(IOrderManagementRepository orderManagementRepository)
        {
            _orderManagementRepository = orderManagementRepository ?? throw new ArgumentNullException(nameof(orderManagementRepository));
        }

        [HttpGet("GetOrder")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(Guid customerId)
        {
            try
            {
                var customerIdRequest = new CustomerIdRequest { Id = customerId };
                var orderResponse = await _orderManagementRepository.GetOrderByCustomerIdAsync(customerIdRequest);

                if (orderResponse != null)
                {
                    return Ok(orderResponse);
                }

                // اگر داده‌ای یافت نشد، می‌توانید یک پاسخ مناسب ارسال کنید.
                return NotFound("Order not found for the given customer ID.");
            }
            catch (Exception ex)
            {
                // مدیریت خطاهایی که ممکن است در زمان اجرا رخ دهند
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
