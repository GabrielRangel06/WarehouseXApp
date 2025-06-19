using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WarehouseXApp.Services;

namespace WarehouseXApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentOrders()
        {
            try
            {
                var orders = await _orderService.GetRecentOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching recent orders");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
