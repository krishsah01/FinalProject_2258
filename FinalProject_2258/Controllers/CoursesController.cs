using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject_2258.Data;
using FinalProject_2258.Models;

namespace FinalProject_2258.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses(int? id)
        {
            if (id == null || id == 0)
                return await _context.Courses.Take(5).ToListAsync();

            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourses), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId) return BadRequest("ID mismatch");

            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
