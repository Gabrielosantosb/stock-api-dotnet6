using stock_api_dotnet.ORM.Models.User;

namespace stock_api_dotnet.ORM.Models.Paciente
{
    public class PacienteModel : BaseEntity
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }

        public UserModel Medico { get; set; }        
        public string MedicoId { get; set; }

    }
}
