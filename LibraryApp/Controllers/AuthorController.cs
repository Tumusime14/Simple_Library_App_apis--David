using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {

        private readonly LibrarydbContext _context;
        public AuthorController(LibrarydbContext context)
        {
            _context = context;
        }
        // GET all request API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return Ok(authors);

        }

        //GET unique data item request API
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthors(int id)
        {
            return await _context.Authors.FindAsync(id);
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        //Post request API
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthors), author);
        }


        //Delete request API
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }
            _context.Authors.Remove(author);

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
