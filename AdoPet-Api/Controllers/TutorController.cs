using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using AdoPet_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _tutorRepository;
        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tutor>>> GetTutors()
        {
            List<Tutor> tutors = await _tutorRepository.GetTutors();
            return Ok(tutors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tutor>>> BuscarPorId(int id)
        {
            Tutor tutor = await _tutorRepository.GetTutorById(id);
            return Ok(tutor);
        }
        [HttpPost]
        public async Task<ActionResult<Tutor>> Cadastrar([FromBody] Tutor tutorModel)
        {
            Tutor tutor= await _tutorRepository.CreateTutor(tutorModel);

            return Ok(tutor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Tutor>> Atualizar([FromBody] Tutor tutorModel, int id)
        {
            tutorModel.Id = id;
            Tutor tutor= await _tutorRepository.UpdateTutor(tutorModel, id);

            return Ok(tutor);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tutor>> Apagar(int id)
        {
            bool apagado = await _tutorRepository.DeleteTutor(id);
            return Ok(apagado);
        }

    }
}
