using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using AdoPet_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterRepository _shelterRepository;
        public ShelterController(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Shelter>>> GetShelters()
        {
            List<Shelter> Shelters = await _shelterRepository.GetShelters();
            return Ok(Shelters);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Shelter>>> BuscarPorId(int id)
        {
            Shelter Shelter = await _shelterRepository.GetShelterById(id);
            return Ok(Shelter);
        }
        [HttpPost]
        public async Task<ActionResult<Shelter>> Cadastrar([FromBody] Shelter ShelterModel)
        {
            Shelter Shelter = await _shelterRepository.CreateShelter(ShelterModel);

            return Ok(Shelter);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Shelter>> Atualizar([FromBody] Shelter ShelterModel, int id)
        {
            ShelterModel.Id = id;
            Shelter Shelter = await _shelterRepository.UpdateShelter(ShelterModel, id);

            return Ok(Shelter);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shelter>> Apagar(int id)
        {
            bool apagado = await _shelterRepository.DeleteShelter(id);
            return Ok(apagado);
        }

    }
}
