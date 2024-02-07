using Microsoft.EntityFrameworkCore;
using stock_api_dotnet.ORM.Context;

namespace stock_api_dotnet.Code
{
    public static class DefineMigrationsMysql
    {        
            public static void Init(IServiceProvider services)
            {
                var serviceScope = services.CreateScope();
                var serviceDb = serviceScope.ServiceProvider
                                       .GetService<StockDbContext>();

                serviceDb?.Database.Migrate();
            }
        }
    }
