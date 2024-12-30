using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Category
{
    [BsonId] 
    public ObjectId Id { get; set; }
    
    public required string CategoryName { get; set; } 

    public required List<Product> Products { get; set; } 
}


public class Product
{
    public required string Id { get; set; } 

    public required string Name { get; set; } 

    public decimal Price { get; set; } 
}
