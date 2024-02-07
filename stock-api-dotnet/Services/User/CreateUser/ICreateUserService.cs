using System.Threading.Tasks;
using stock_api_dotnet.ORM.Models.User;

public interface ICreateUserService
{
    Task<string> CreateUser(CreateUserModel user);
}
