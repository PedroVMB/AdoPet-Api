using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using AdoPet_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class AdoptionController : ControllerBase
    {
        private readonly IAdoptionRepository _adoptionRepository;

        public AdoptionController(IAdoptionRepository adoptionRepository)
        {
            _adoptionRepository = adoptionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdoption(int petId, int tutorId)
        {
            try
            {
                var adoption = await _adoptionRepository.NewAdoption(petId, tutorId);
                return Ok(adoption);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
