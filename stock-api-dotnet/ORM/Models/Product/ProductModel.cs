using stock_api_dotnet.ORM.Models.Category;

namespace stock_api_dotnet.ORM.Models.Product
{
    public class ProductModel
    {
        public int Product_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
