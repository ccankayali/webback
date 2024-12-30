using MongoDB.Driver;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByNameAsync(string name);
    Task<Category> CreateCategoryAsync(Category newCategory);
    Task AddProductsToCategoryCollectionAsync(string categoryName, List<Product> products);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoDatabase _database;

    public CategoryRepository(IMongoClient client)
    {
        _database = client.GetDatabase("CategoryDb");
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var collection = _database.GetCollection<Category>("Categories");
        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var collection = _database.GetCollection<Category>("Categories");
        return await collection.Find(c => c.CategoryName.ToLower() == name.ToLower()).FirstOrDefaultAsync();
    }

    public async Task<Category> CreateCategoryAsync(Category newCategory)
    {
        var collection = _database.GetCollection<Category>("Categories");

        // MongoDB `_id` alanını otomatik olarak atayacak
        await collection.InsertOneAsync(newCategory);

        return newCategory;
    }

    public async Task AddProductsToCategoryCollectionAsync(string categoryName, List<Product> products)
    {
        var categoryCollection = _database.GetCollection<Product>(categoryName);

        // Ürünleri ilgili koleksiyona ekliyoruz
        await categoryCollection.InsertManyAsync(products);
    }
}
