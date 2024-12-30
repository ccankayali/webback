using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order newOrder);
    Task<List<Order>> GetOrdersAsync();
}
