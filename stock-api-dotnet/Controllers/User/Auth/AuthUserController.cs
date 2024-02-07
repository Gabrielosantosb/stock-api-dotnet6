using Microsoft.AspNetCore.Mvc;
using stock_api_dotnet.ORM.Models.User;

[Route("api/[controller]")]
[ApiController]
public class AuthUserController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthUserController(IAuthService authService)
    {
        _authService = authService;
    }
}

//    [HttpPost("login")]
//    public async Task<IActionResult> Login([FromBody] AuthUserModel loginModel)
//    {
//        try
//        {
//            var result = await _authService.AuthenticateUser(loginModel);
//            return Ok(new { Status = result });
//        }
//        catch (UnauthorizedAccessException ex)
//        {
//            return Unauthorized(new { Status = "Authentication failed", Message = ex.Message });
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { Status = "Error authenticating user", Message = ex.Message });
//        }
//    }
//}
