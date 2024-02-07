using stock_api_dotnet.ORM.Models.User;
using stock_api_dotnet.Repository; 

public class CreateUserService : ICreateUserService
{
    private readonly BaseRepository<UserModel> _userRepository;

    public CreateUserService(BaseRepository<UserModel> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> CreateUser(CreateUserModel createUserModel)
    {
        try
        {
            var uniqueId = GenerateUniqueId();
            var userModel = new UserModel
            {
                Id = uniqueId,
                UserName = createUserModel.UserName,
                Email = createUserModel.Email,
                Password = createUserModel.Password
            };

            var createdUser = _userRepository.Create(userModel);
            
            return createdUser.Id;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro criar usuário", ex);
        }
    }
    private string GenerateUniqueId()
    {
        string randomString = Guid.NewGuid().ToString();
        string uniqueId = randomString; 
        
        while (_userRepository.Exists(uniqueId))
        {
            randomString = Guid.NewGuid().ToString();
            uniqueId = randomString;
        }

        
        return uniqueId;
    }
}

