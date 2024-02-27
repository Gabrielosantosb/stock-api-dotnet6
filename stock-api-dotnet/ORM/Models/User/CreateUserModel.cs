namespace stock_api_dotnet.ORM.Models.User
{
    public class CreateUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
