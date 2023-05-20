using AdoPet_Api.Model;
using AdoPet_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly TutorService _service;
        public TutorController(TutorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tutor>>> GetTutors()
        {
            List<Tutor> tutors = await _service.GetTutors();
            return Ok(tutors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tutor>>> BuscarPorId(int id)
        {
            Tutor tutor = await _service.GetTutorById(id);
            return Ok(tutor);
        }
        [HttpPost]
        public async Task<ActionResult<Tutor>> Cadastrar([FromBody] Tutor tutorModel)
        {
            Tutor tutor= await _service.CreateTutor(tutorModel);

            return Ok(tutor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Tutor>> Atualizar([FromBody] Tutor tutorModel, int id)
        {
            tutorModel.Id = id;
            Tutor tutor= await _service.UpdateTutor(tutorModel, id);

            return Ok(tutor);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tutor>> Apagar(int id)
        {
            bool apagado = await _service.DeleteTutor(id);
            return Ok(apagado);
        }

    }
}
