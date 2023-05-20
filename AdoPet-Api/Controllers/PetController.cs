using AdoPet_Api.Model;
using AdoPet_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _service;
        public PetController(PetService petService)
        {
            _service = petService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetPets()
        {
            List<Pet> Pet = await _service.GetPets();
            return Ok(Pet);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pet>>> GetPetById(int id)
        {
            Pet Pet = await _service.GetPetById(id);
            return Ok(Pet);
        }
        [HttpPost]
        public async Task<ActionResult<Pet>> Cadastrar([FromBody] Pet PetModel)
        {
            Pet Pet = await _service.CreatePet(PetModel);

            return Ok(Pet);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Pet>> Atualizar([FromBody] Pet PetModel, int id)
        {
            PetModel.Id = id;
            Pet Pet = await _service.UpdatePet(PetModel, id);

            return Ok(Pet);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> Apagar(int id)
        {
            bool apagado = await _service.DeletePet(id);
            return Ok(apagado);
        }
    }
}
