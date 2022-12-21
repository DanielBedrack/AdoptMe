using AdoptMe1.Models;
using AdpotMe1API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdpotMe1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private ApiAnimalContext _context;
        public PetsController(ApiAnimalContext context)
        {
            _context = context;
        }

        [HttpGet("AllAnimals")]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimalsAsync()
        {
            return Ok(await _context.Animals!.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetOneAnimalAsync(int id)
        {
            Animal animal = await _context.Animals!.FindAsync(id);

            if(animal == null)
            {
                return BadRequest();
            }
            return Ok(animal);
        }

    }
}
