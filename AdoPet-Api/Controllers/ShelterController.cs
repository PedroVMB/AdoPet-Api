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
        private readonly IAdoptionRepository _adoptionRepository;
        public ShelterController(IShelterRepository shelterRepository, IAdoptionRepository adoptionRepository)
        {
            _shelterRepository = shelterRepository;
            _adoptionRepository = adoptionRepository;
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

        [HttpDelete("cancelAdoption/{id}")]
        public async Task<IActionResult> CancelAdoption(Guid id)
        {
            try
            {
                var result = await _adoptionRepository.CancelAdoption(id);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
