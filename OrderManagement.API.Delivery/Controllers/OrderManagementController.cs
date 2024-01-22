using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.Delivery.DTO.InternalAPIModel.Request;
using OrderManagement.API.Delivery.DTO.InternalAPIModel.Response;
using OrderManagement.API.Delivery.INfrastructure.Repository;

namespace OrderManagement.API.Delivery.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManagementRepository _orderRepository;

        public OrderController(IOrderManagementRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrderByCustomerId(Guid customerId)
        {
            var customerIdRequest = new CustomerIdRequest { Id = customerId };
            var orderResponse = await _orderRepository.GetOrderByCustomerIdAsync(customerIdRequest);

            if (orderResponse == null)
            {
                return NotFound();
            }

            return Ok(orderResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var ordersResponse = await _orderRepository.GetAllOrdersAsync();
            return Ok(ordersResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderRequest orderRequest)
        {
            var orderResponse = await _orderRepository.AddOrderAsync(orderRequest);
            return CreatedAtAction(nameof(GetOrderByCustomerId), new { customerId = orderResponse.Id }, orderResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequest orderRequest)
        {
            var updatedOrderResponse = await _orderRepository.UpdateOrderAsync(orderRequest);

            if (updatedOrderResponse == null)
            {
                return NotFound();
            }

            return Ok(updatedOrderResponse);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var isDeleted = await _orderRepository.DeleteOrderAsync(orderId);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}