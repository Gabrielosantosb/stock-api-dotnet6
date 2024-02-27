using Microsoft.AspNetCore.Mvc;
using stock_api_dotnet.Repository;
using stock_api_dotnet.ORM.Models.Paciente;
using System;

namespace stock_api_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly BaseRepository<PacienteModel> _pacienteRepository;

        public PacientesController(BaseRepository<PacienteModel> pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pacientes = _pacienteRepository.FindAll();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paciente = _pacienteRepository.FindById(id.ToString());
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PacienteModel paciente)
        {
            if (paciente == null)
            {
                return BadRequest("Invalid data");
            }

            _pacienteRepository.Create(paciente);

            return CreatedAtRoute("Get", new { id = paciente.Id }, paciente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PacienteModel paciente)
        {
            if (paciente == null || id != paciente.Id)
            {
                return BadRequest("Invalid data");
            }

            var existingPaciente = _pacienteRepository.FindById(id.ToString());

            if (existingPaciente == null)
            {
                return NotFound();
            }

            _pacienteRepository.Update(paciente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paciente = _pacienteRepository.FindById(id.ToString());
            if (paciente == null)
            {
                return NotFound();
            }

            _pacienteRepository.Delete(id.ToString());

            return NoContent();
        }
    }
}
