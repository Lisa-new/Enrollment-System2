using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enrollment_System.Models;

namespace Enrollment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentItem>>> GetStudentItems()
        {
            return await _context.StudentItems.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentItem>> GetStudentItem(int id)

        {
            var studentItem = await _context.StudentItems.FindAsync(id);

            if (studentItem == null)
            {
                return NotFound();
            }

            return studentItem;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentItem(int id, StudentItem studentItem)
        {
            if (id != studentItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentItem>> PostStudentItem(StudentItem studentItem)
        {
            _context.StudentItems.Add(studentItem);
            await _context.SaveChangesAsync();

           // return CreatedAtAction("GetStudentItem", new { id = studentItem.Id }, studentItem);
           return CreatedAtAction(nameof(GetStudentItem), new { id = studentItem.Id }, studentItem);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentItem(int id)
        {
            var studentItem = await _context.StudentItems.FindAsync(id);
            if (studentItem == null)
            {
                return NotFound();
            }

            _context.StudentItems.Remove(studentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentItemExists(int id)
        {
            return _context.StudentItems.Any(e => e.Id == id);
        }
    }
}
