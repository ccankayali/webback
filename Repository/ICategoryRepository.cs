using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync(int page, int pageSize);
    Task<Category> GetCategoryByNameAsync(string name);
    Task<Category> CreateCategoryAsync(Category newCategory);
    Task<Category> UpdateCategoryAsync(string categoryName, Category updatedCategory);
    Task DeleteCategoryAsync(string categoryName);
    Task AddProductsToCategoryCollectionAsync(string categoryName, List<Product> products);
}
