using System.Collections.Generic;
using System.Threading.Tasks;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> CreateOrderAsync(Order newOrder)
    {
        return await _orderRepository.CreateOrderAsync(newOrder);
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetOrdersAsync();
    }
}
