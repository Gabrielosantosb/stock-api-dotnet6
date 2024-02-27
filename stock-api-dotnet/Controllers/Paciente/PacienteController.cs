using Microsoft.AspNetCore.Mvc;
using stock_api_dotnet.ORM.Models.Paciente;
using stock_api_dotnet.ORM.Models.Product;
using stock_api_dotnet.Services;
using stock_api_dotnet.Services.Paciente;

namespace stock_api_dotnet.Controllers.Paciente
{
    public class PacienteController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly IPacienteService  _pacienteService;

            public ProductController(IPacienteService pacienteService)
            {
                _pacienteService = pacienteService ?? throw new ArgumentNullException(nameof(pacienteService));
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<PacienteModel>>> GetPacientes()
            {
                return Ok(await _pacienteService.GetPacientes());

            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ProductModel>> GetPaciente(int id)
            {
                var product = await _pacienteService.GetPaciente(id);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }

            [HttpPost]
            public async Task<ActionResult<ProductModel>> CreatePaciente(PacienteModel paciente)
            {
                try
                {
                    var createdProduct = await _pacienteService.CreatePaciente(paciente);
                    return Ok(createdProduct);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdatePaciente(int id, PacienteModel product)
            {
                try
                {
                    await _pacienteService.UpdatePaciente(id, product);
                    return NoContent();
                }
                catch (ArgumentException)
                {
                    return BadRequest("Invalid product id");
                }
                catch (DirectoryNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }

            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePaciente(int id)
            {
                try
                {
                    await _pacienteService.DeletePaciente(id);
                    return NoContent();
                }
                catch (DirectoryNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }
        }
}
