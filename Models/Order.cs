using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Order
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string CustomerName { get; set; }

    public List<OrderItem> Items { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }
}

public class OrderItem
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
