using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // Create a new order
    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] Order newOrder)
    {
        if (newOrder == null || newOrder.Items == null || newOrder.Items.Count == 0)
        {
            return BadRequest("Invalid order data.");
        }

        newOrder.TotalAmount = newOrder.Items.Sum(item => item.Price * item.Quantity);
        newOrder.OrderDate = DateTime.UtcNow;

        var createdOrder = await _orderService.CreateOrderAsync(newOrder);

        return CreatedAtAction(nameof(GetOrders), new { id = createdOrder.Id }, createdOrder);
    }

    // Get all orders
    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetOrders()
    {
        var orders = await _orderService.GetOrdersAsync();
        return Ok(orders);
    }
}
