using System;
using FinalProject_2258.Data;
using FinalProject_2258.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_2258.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbyController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hobbies = await _context.Hobbies.ToListAsync();
            return Ok(hobbies);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);

            if (hobby == null)
                return NotFound();

            return Ok(hobby);
        }

        // POST (Create)
        [HttpPost]
        public async Task<IActionResult> Create(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return Ok(hobby);
        }

        // PUT (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hobby hobby)
        {
            if (id != hobby.HobbyId)
                return BadRequest("ID mismatch");

            _context.Entry(hobby).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(hobby);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
                return NotFound();

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}
