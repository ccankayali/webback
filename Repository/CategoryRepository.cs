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

    // Sayfalama ve _id dışlama
    public async Task<List<Category>> GetCategoriesAsync(int page, int pageSize)
    {
        var collection = _database.GetCollection<Category>("Categories");

        // Pagination
        var skip = (page - 1) * pageSize;
        var filter = Builders<Category>.Filter.Empty; // Tüm verileri alıyoruz
        var projection = Builders<Category>.Projection.Exclude("_id"); // _id'yi dışlıyoruz

        // Sayfalama ve projeksiyon
        var categories = await collection.Find(filter)
            .Skip(skip)
            .Limit(pageSize)
            .Project<Category>(projection)
            .ToListAsync();

        return categories;
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        var collection = _database.GetCollection<Category>("Categories");

        // Kategori adı ile sorgu yapıyoruz
        var filter = Builders<Category>.Filter.Eq(c => c.CategoryName, name);
        var projection = Builders<Category>.Projection.Exclude("_id"); // _id'yi dışlıyoruz

        return await collection.Find(filter).Project<Category>(projection).FirstOrDefaultAsync();
    }

    public async Task<Category> CreateCategoryAsync(Category newCategory)
    {
        var collection = _database.GetCollection<Category>("Categories");

        // Kategoriyi MongoDB'ye eklerken, _id'yi MongoDB otomatik olarak atar
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
