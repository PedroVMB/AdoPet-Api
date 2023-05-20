using AdoPet_Api.Model;
using AdoPet_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly ShelterService _service;
        public ShelterController(ShelterService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Shelter>>> GetShelters()
        {
            List<Shelter> Shelters = await _service.GetShelters();
            return Ok(Shelters);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Shelter>>> BuscarPorId(int id)
        {
            Shelter Shelter = await _service.GetShelterById(id);
            return Ok(Shelter);
        }
        [HttpPost]
        public async Task<ActionResult<Shelter>> Cadastrar([FromBody] Shelter ShelterModel)
        {
            Shelter Shelter = await _service.CreateShelter(ShelterModel);

            return Ok(Shelter);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Shelter>> Atualizar([FromBody] Shelter ShelterModel, int id)
        {
            ShelterModel.Id = id;
            Shelter Shelter = await _service.UpdateShelter(ShelterModel, id);

            return Ok(Shelter);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shelter>> Apagar(int id)
        {
            bool apagado = await _service.DeleteShelter(id);
            return Ok(apagado);
        }

    }
}
