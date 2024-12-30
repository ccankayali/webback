using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Category
{
    [BsonId]  // This tells MongoDB to use this property for the _id field
    public ObjectId Id { get; set; }  // This will now map to MongoDB's _id field
    
    public string CategoryName { get; set; } // Category name

    public List<Product> Products { get; set; } // List of products
}


public class Product
{
    public string Id { get; set; } // MongoDB'den gelen _id string olarak alınır.

    public string Name { get; set; } // Ürün adı

    public decimal Price { get; set; } // Ürün fiyatı
}
