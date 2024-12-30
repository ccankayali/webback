using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(Order newOrder);
    Task<List<Order>> GetOrdersAsync();
}
