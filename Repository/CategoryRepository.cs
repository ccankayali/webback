using MongoDB.Driver;
using YourNamespace.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoDatabase _database;

    public CategoryRepository(IMongoClient client)
    {
        _database = client.GetDatabase("CategoryDb");
    }

    public async Task<List<Category>> GetCategoriesAsync(int page, int pageSize)
    {
        var collection = _database.GetCollection<Category>("Categories");

        var skip = (page - 1) * pageSize;
        var filter = Builders<Category>.Filter.Empty;

        var categories = await collection.Find(filter)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();

        return categories;
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var collection = _database.GetCollection<Category>("Categories");

        var filter = Builders<Category>.Filter.Eq(c => c.CategoryName, name);
        var projection = Builders<Category>.Projection.Exclude("_id");

        return await collection.Find(filter).Project<Category>(projection).FirstOrDefaultAsync();
    }

    public async Task<Category> CreateCategoryAsync(Category newCategory)
    {
        var collection = _database.GetCollection<Category>("Categories");

        await collection.InsertOneAsync(newCategory);
        return newCategory;
    }

    public async Task<Category> UpdateCategoryAsync(string categoryName, Category updatedCategory)
    {
        var collection = _database.GetCollection<Category>("Categories");

        var filter = Builders<Category>.Filter.Eq(c => c.CategoryName, categoryName);
        var update = Builders<Category>.Update.Set(c => c.CategoryName, updatedCategory.CategoryName)
                                                .Set(c => c.Products, updatedCategory.Products);

        var result = await collection.FindOneAndUpdateAsync(filter, update);
        return result;
    }

    public async Task DeleteCategoryAsync(string categoryName)
    {
        var collection = _database.GetCollection<Category>("Categories");

        var filter = Builders<Category>.Filter.Eq(c => c.CategoryName, categoryName);
        await collection.DeleteOneAsync(filter);
    }

    public async Task AddProductsToCategoryCollectionAsync(string categoryName, List<Product> products)
    {
        var categoryCollection = _database.GetCollection<Product>(categoryName);

        await categoryCollection.InsertManyAsync(products);
    }
}
