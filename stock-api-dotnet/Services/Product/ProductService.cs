using Microsoft.EntityFrameworkCore;
using stock_api_dotnet.ORM.Context;
using stock_api_dotnet.ORM.Models.Product;

namespace stock_api_dotnet.Services
{
    public class ProductServices : IProductServices
    {
        private readonly StockDbContext _context;

        public ProductServices(StockDbContext context)
        {
            _context = context;
        }
        private static IEnumerable<ProductModel> RoundPrices(IEnumerable<ProductModel> products)
        {
            return products.Select(product =>{
                product.Price = RoundPrice(product.Price);
                return product;
            });
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var products = await _context.Products
                       .Include(p => p.Category)
                        .ToListAsync();

            return RoundPrices(products);
            
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Product_id == id);

            if (product != null)
            {
                return RoundPrices(new List<ProductModel> { product }).FirstOrDefault();
            }

            return null;
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var createdProduct = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Product_id == product.Product_id);

            return createdProduct;
        }

        public async Task UpdateProduct(int id, ProductModel product)
        {
            if (id != product.Product_id)
                throw new ArgumentException("Invalid product id");

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    throw new DirectoryNotFoundException($"Product with id {id} not found");
                else
                    throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new DirectoryNotFoundException($"Product with id {id} not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Product_id == id);
        }

        private static decimal RoundPrice(decimal price)
        {
            return decimal.Round(price, 2);
        }
    }
}
