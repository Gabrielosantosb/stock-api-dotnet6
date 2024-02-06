using stock_api_dotnet.ORM.Models.Category;

namespace stock_api_dotnet.Services.Category
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(int id);
        Task<CategoryModel> CreateCategory(CategoryModel category);
        Task UpdateCategory(int id, CategoryModel category);
        Task DeleteCategory(int id);
    }
}
