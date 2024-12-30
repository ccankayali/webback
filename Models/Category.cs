using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Category
{
    [BsonIgnore] // Bu, `_id` alanını yok sayar ve modelde yer almaz.
    public ObjectId Id { get; set; }  // Bu alan MongoDB'den gelir ancak modelde kullanılmaz.
    
    public string CategoryName { get; set; } // Kategori adı

    public List<Product> Products { get; set; } // Kategoriye ait ürünler
}

public class Product
{
    public string Id { get; set; } // MongoDB'den gelen _id string olarak alınır.

    public string Name { get; set; } // Ürün adı

    public decimal Price { get; set; } // Ürün fiyatı
}
