public interface IAuthUserService
{
    Task<bool> AuthenticateUser(string username, string password);
}