using Microsoft.AspNetCore.Mvc;
using stock_api_dotnet.ORM.Models.User;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthUserService _authUserService;

    public AuthController(IAuthUserService authUserService)
    {
        _authUserService = authUserService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthUserModel loginRequest)
    {
        try
        {
            bool isAuthenticated = await _authUserService.AuthenticateUser(loginRequest.Email, loginRequest.Password);

            if (isAuthenticated)
            {                
                var authToken = GenerateAuthToken();
                return Ok(new { Status = "Login bem-sucedido", Token = authToken });
            }
            else
            {
                return Unauthorized(new { Status = "Falha na autenticação", Message = "Credenciais inválidas" });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { Status = "Erro durante a autenticação", Message = ex.Message });
        }
    }

    
    private string GenerateAuthToken()
    {
        // fazer logica geracao de token aqui
        return "token_gerado";
    }
}

