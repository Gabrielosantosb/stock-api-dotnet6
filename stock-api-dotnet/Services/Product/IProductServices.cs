using stock_api_dotnet.ORM.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stock_api_dotnet.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int id);
        Task<ProductModel> CreateProduct(ProductModel product);
        Task UpdateProduct(int id, ProductModel product);
        Task DeleteProduct(int id);
    }
}
