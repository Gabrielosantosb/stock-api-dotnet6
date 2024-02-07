//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using stock_api_dotnet.ORM.Models.User;

//public class AuthService : IAuthService
//{
//    private readonly UserManager<UserModel> _userManager;
//    private readonly SignInManager<UserModel> _signInManager;

//    public AuthService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//    }

//    public async Task<string> AuthenticateUser(AuthUserModel loginModel)
//    {
//        var user = await _userManager.FindByEmailAsync(loginModel.Email);

//        if (user != null)
//        {
//            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

//            if (result.Succeeded)
//            {                
//                return "Authentication successful";
//            }
//        }

//        throw new UnauthorizedAccessException("Invalid email or password");
//    }
//}
