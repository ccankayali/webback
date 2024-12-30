using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

public interface ICategoryService
{
    Task<List<Category>> GetCategoriesAsync(int page, int pageSize);  // Sayfalı kategorileri almak
    Task<Category> GetCategoryByNameAsync(string name);  // Kategori adına göre arama
    Task<Category> CreateCategoryAsync(Category newCategory);  // Yeni kategori oluşturma
}
