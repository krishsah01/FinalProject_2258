using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject_2258.Data;
using FinalProject_2258.Models;

namespace FinalProject_2258.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets(int? id)
        {
            if (id == null || id == 0)
                return await _context.Pets.Take(5).ToListAsync();

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();

            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> CreatePet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPets), new { id = pet.PetId }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, Pet pet)
        {
            if (id != pet.PetId) return BadRequest("ID mismatch");

            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
