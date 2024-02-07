using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_api_dotnet.ORM.Models
{
    public class BaseEntity
    {
        [Key]        
        public string Id { get; set; }
    }
}
