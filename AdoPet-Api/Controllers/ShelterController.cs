using AdoPet_Api.Data.Dto;
using AdoPet_Api.Data;
using AdoPet_Api.Model;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelterController : ControllerBase
    {
        private TutorContext _context;
        private IMapper _mapper;

        public ShelterController(TutorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateShelter([FromBody] CreateShelterDto ShelterDto)
        {
            ShelterModel Shelter = _mapper.Map<ShelterModel>(ShelterDto);
            await _context.Shelters.AddAsync(Shelter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShelterId), new { id = Shelter.Id }, Shelter);
        }

        [HttpGet]
        public async Task<List<ReadShelterDto>> GetShelters()
        {
            var Shelteres = await _context.Shelters.ToListAsync();
            var readShelterDtos = _mapper.Map<List<ReadShelterDto>>(Shelteres);

            return readShelterDtos;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShelterId(int id)
        {
            var Shelter = await _context.Shelters.FindAsync(id);
            if (Shelter == null) return NotFound();
            var ShelterDto = _mapper.Map<ReadShelterDto>(Shelter);
            return Ok(ShelterDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShelter(int id, [FromBody] UpdateShelterDto ShelterDto)
        {
            var Shelter = await _context.Shelters.FindAsync(id);
            if (Shelter == null) return NotFound();
            _mapper.Map(ShelterDto, Shelter);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateShelterPartial(int id, JsonPatchDocument<UpdateShelterDto> patch)
        {
            var Shelter = await _context.Shelters.FindAsync(id);
            if (Shelter == null) return NotFound();

            var ShelterToUpdate = _mapper.Map<UpdateShelterDto>(Shelter);

            patch.ApplyTo(ShelterToUpdate, ModelState);

            if (!TryValidateModel(ShelterToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ShelterToUpdate, Shelter);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShelter(int id)
        {
            var Shelter = await _context.Shelters.FindAsync(id);
            if (Shelter == null) return NotFound();
            _context.Shelters.Remove(Shelter);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
