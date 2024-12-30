using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoDatabase _database;

    public OrderRepository(IMongoClient client)
    {
        _database = client.GetDatabase("OrderDb");
    }

    public async Task<Order> CreateOrderAsync(Order newOrder)
    {
        var collection = _database.GetCollection<Order>("Orders");
        await collection.InsertOneAsync(newOrder);
        return newOrder;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        var collection = _database.GetCollection<Order>("Orders");
        return await collection.Find(_ => true).ToListAsync();
    }
}
