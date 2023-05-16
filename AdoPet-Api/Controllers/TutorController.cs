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
    public class TutorController : ControllerBase
    {
        private TutorContext _context;
        private IMapper _mapper;

        public TutorController(TutorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="tutorDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateTutor([FromBody] CreateTutorDto tutorDto)
        {
            TutorModel tutor = _mapper.Map<TutorModel>(tutorDto);
            await _context.Tutores.AddAsync(tutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTutorId), new { id = tutor.Id }, tutor);
        }

        [HttpGet]
        public async Task<List<ReadTutorDto>> GetTutors()
        {
            var tutores = await _context.Tutores.ToListAsync();
            var readTutorDtos = _mapper.Map<List<ReadTutorDto>>(tutores);

            return readTutorDtos;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutorId(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null) return NotFound();
            var tutorDto = _mapper.Map<ReadTutorDto>(tutor);
            return Ok(tutorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTutor(int id, [FromBody] UpdateTutorDto tutorDto)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null) return NotFound();
            _mapper.Map(tutorDto, tutor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTutorPartial(int id, JsonPatchDocument<UpdateTutorDto> patch)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if (tutor == null) return NotFound();

            var tutorToUpdate =  _mapper.Map<UpdateTutorDto>(tutor);

            patch.ApplyTo(tutorToUpdate, ModelState);

            if (!TryValidateModel(tutorToUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(tutorToUpdate, tutor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);
            if(tutor == null) return NotFound();
            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
