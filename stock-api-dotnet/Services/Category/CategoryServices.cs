using Microsoft.EntityFrameworkCore;
using stock_api_dotnet.ORM.Context;
using stock_api_dotnet.ORM.Models.Category;
using stock_api_dotnet.Services.Category;

namespace stock_api_dotnet.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly StockDbContext _context;

        public CategoryService(StockDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<CategoryModel> CreateCategory(CategoryModel category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task UpdateCategory(int id, CategoryModel category)
        {
            if (id != category.Category_id)
                throw new ArgumentException("Invalid category id");

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                    throw new DirectoryNotFoundException($"Category with id {id} not found");
                else
                    throw;
            }
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                throw new DirectoryNotFoundException($"Category with id {id} not found");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Category_id == id);
        }
    }
}
