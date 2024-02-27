using stock_api_dotnet.ORM.Models.Paciente;
using stock_api_dotnet.ORM.Models.Product;

namespace stock_api_dotnet.Services.Paciente
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteModel>> GetPacientes();
        Task<PacienteModel> GetPaciente(int id);
        Task<PacienteModel> CreatePaciente(PacienteModel product);
        Task UpdatePaciente(int id, PacienteModel product);
        Task DeletePaciente(int id);
    }
}
