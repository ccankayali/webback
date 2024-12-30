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
        // Kategoriyi kaydediyoruz
        var createdCategory = await _categoryRepository.CreateCategoryAsync(newCategory);

        // Kategoriye ait ürünleri ayrı bir koleksiyona ekliyoruz
        await _categoryRepository.AddProductsToCategoryCollectionAsync(newCategory.CategoryName, newCategory.Products);

        return createdCategory;
    }
}
