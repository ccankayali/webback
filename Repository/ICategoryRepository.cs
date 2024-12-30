using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync(int page, int pageSize);  // Sayfalı kategorileri almak
    Task<Category> GetCategoryByNameAsync(string name);  // Kategori adına göre arama
    Task<Category> CreateCategoryAsync(Category newCategory);  // Yeni kategori oluşturma
    Task AddProductsToCategoryCollectionAsync(string categoryName, List<Product> products);  // Ürün ekleme
}
