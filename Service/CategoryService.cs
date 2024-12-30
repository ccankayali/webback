using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetCategoriesAsync(int page, int pageSize)
    {
        return await _categoryRepository.GetCategoriesAsync(page, pageSize);
    }

    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        return await _categoryRepository.GetCategoryByNameAsync(name);
    }

    public async Task<Category> CreateCategoryAsync(Category newCategory)
    {
        var createdCategory = await _categoryRepository.CreateCategoryAsync(newCategory);
        await _categoryRepository.AddProductsToCategoryCollectionAsync(newCategory.CategoryName, newCategory.Products);
        return createdCategory;
    }

    public async Task<Category> UpdateCategoryAsync(string categoryName, Category updatedCategory)
    {
        return await _categoryRepository.UpdateCategoryAsync(categoryName, updatedCategory);
    }

    public async Task DeleteCategoryAsync(string categoryName)
    {
        await _categoryRepository.DeleteCategoryAsync(categoryName);
    }
}
