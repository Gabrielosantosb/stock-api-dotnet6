using stock_api_dotnet.ORM.Models.Paciente;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_api_dotnet.ORM.Models.User
{
    //public class UserModel :BaseEntity
    public class UserModel : BaseEntity
    {     
                
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<PacienteModel> Pacientes { get; set; }
    }
}
