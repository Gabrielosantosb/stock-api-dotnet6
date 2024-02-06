using Microsoft.AspNetCore.Mvc;
using stock_api_dotnet.Services;
using stock_api_dotnet.ORM.Models.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using stock_api_dotnet.Services.Category;

namespace stock_api_dotnet.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryService;

        public CategoryController(ICategoryServices categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult<CategoryModel>> PostCategory(CategoryModel category)
        {
            var createdCategory = await _categoryService.CreateCategory(category);

            var routeValues = new { id = createdCategory.Category_id };
            var response = new
            {
                Status = "Category Created Successfully",
                Category = createdCategory
            };

            return CreatedAtAction(nameof(GetCategoryById), routeValues, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryModel category)
        {
            try
            {
                await _categoryService.UpdateCategory(id, category);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid category id");
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
