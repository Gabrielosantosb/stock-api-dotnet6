using stock_api_dotnet.ORM.Context;
using stock_api_dotnet.Services.Auth;

public class AuthUserService : IAuthUserService
{
    private readonly StockDbContext _context;

    public AuthUserService(StockDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AuthenticateUser(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user != null)
        {
    
            bool isPasswordCorrect = VerifyPassword(password, user.Password);

            return isPasswordCorrect;
        }

        return false;
    }

    
    private bool VerifyPassword(string enteredPassword, string storedPassword)
    {
        
        return enteredPassword == storedPassword;
    }
}
