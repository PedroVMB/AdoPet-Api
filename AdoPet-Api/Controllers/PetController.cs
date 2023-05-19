using AdoPet_Api.Data;
using AdoPet_Api.Data.Dto;
using AdoPet_Api.Model;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private TutorContext _context;
        private IMapper _mapper;

        public PetController(TutorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePet([FromBody] CreatePetDto PetDto)
        {
            PetModel Pet = _mapper.Map<PetModel>(PetDto);
            await _context.Pets.AddAsync(Pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPetId), new { id = Pet.Id }, Pet);
        }

        [HttpGet]
        public async Task<List<ReadPetDto>> GetPets()
        {
            var Petes = await _context.Pets.ToListAsync();
            var readPetDtos = _mapper.Map<List<ReadPetDto>>(Petes);

            return readPetDtos;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetId(int id)
        {
            var Pet = await _context.Pets.FindAsync(id);
            if (Pet == null) return NotFound();
            var PetDto = _mapper.Map<ReadPetDto>(Pet);
            return Ok(PetDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] UpdatePetDto PetDto)
        {
            var Pet = await _context.Pets.FindAsync(id);
            if (Pet == null) return NotFound();
            _mapper.Map(PetDto, Pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePetPartial(int id, JsonPatchDocument<UpdatePetDto> patch)
        {
            var Pet = await _context.Pets.FindAsync(id);
            if (Pet == null) return NotFound();

            var PetToUpdate = _mapper.Map<UpdatePetDto>(Pet);

            patch.ApplyTo(PetToUpdate, ModelState);

            if (!TryValidateModel(PetToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(PetToUpdate, Pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var Pet = await _context.Pets.FindAsync(id);
            if (Pet == null) return NotFound();
            _context.Pets.Remove(Pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
