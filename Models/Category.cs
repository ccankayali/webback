using System.Text.Json.Serialization;

public class Category
{
    public string CategoryName { get; set; } // Kategori adı

    public List<Product> Products { get; set; } // Kategoriye ait ürünler
}

public class Product
{
    public string Name { get; set; } // Ürün adı

    public decimal Price { get; set; } // Ürün fiyatı
}
