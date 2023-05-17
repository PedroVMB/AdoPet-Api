using AdoPet_Api.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdoPet_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController
    {
        private TutorContext _context;
        private IMapper _mapper;

        public PetController(TutorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    }
}
