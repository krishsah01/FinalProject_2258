using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject_2258.Data;
using FinalProject_2258.Models;

namespace FinalProject_2258.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------------
        // GET: api/TeamMembers?id=1  (nullable)
        // If id is null or 0 → return first 5 team members
        // ------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.TeamMembers.Take(5).ToListAsync();
            }

            var member = await _context.TeamMembers.FindAsync(id);

            if (member == null)
                return NotFound();

            return Ok(member);
        }

        // ------------------------------------------------------------
        // POST: api/TeamMembers
        // Add new team member
        // ------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult<TeamMember>> CreateTeamMember(TeamMember member)
        {
            _context.TeamMembers.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeamMembers), new { id = member.TeamMemberId }, member);
        }

        // ------------------------------------------------------------
        // PUT: api/TeamMembers/3
        // Update team member
        // ------------------------------------------------------------
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamMember(int id, TeamMember member)
        {
            if (id != member.TeamMemberId)
            {
                return BadRequest("ID mismatch");
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TeamMembers.Any(m => m.TeamMemberId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // ------------------------------------------------------------
        // DELETE: api/TeamMembers/3
        // Delete a member by ID
        // ------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);

            if (member == null)
                return NotFound();

            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
