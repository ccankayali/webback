using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // Sayfalama ile kategorileri alacak endpoint
    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetCategories([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var categories = await _categoryService.GetCategoriesAsync(page, pageSize);
        if (categories == null || categories.Count == 0)
        {
            return NotFound();
        }
        return Ok(categories);
    }

    [HttpGet("{CategoryName}")]
    public async Task<ActionResult<Category>> GetCategoryByName(string CategoryName)
    {
        var category = await _categoryService.GetCategoryByNameAsync(CategoryName);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory([FromBody] Category newCategory)
    {
        if (newCategory == null || string.IsNullOrEmpty(newCategory.CategoryName))
        {
            return BadRequest("Invalid category data.");
        }

        // İstemci tarafından bir ID gönderilmişse, dikkate almayız.
        var createdCategory = await _categoryService.CreateCategoryAsync(newCategory);

        return CreatedAtAction(nameof(GetCategoryByName), new { CategoryName = createdCategory.CategoryName }, createdCategory);
    }
}
