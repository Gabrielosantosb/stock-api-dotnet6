using Microsoft.AspNetCore.Mvc;
using stock_api_dotnet.ORM.Models.User;

[Route("api/[controller]")]
[ApiController]
public class CreateUserController : ControllerBase
{
    private readonly ICreateUserService _createUserService;

    public CreateUserController(ICreateUserService createUserService)
    {
        _createUserService = createUserService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserModel user)
    {
        try
        {
            var userId = await _createUserService.CreateUser(user);
            return Ok(new { UserId = userId, Status = "Usuário criado" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Status = "Erro ao criar usuário", Message = ex.Message });
        }
    }
}
