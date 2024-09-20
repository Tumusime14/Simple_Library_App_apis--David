using LibraryApp.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        // GET all authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return Ok(authors);
        }

        // GET unique author
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST author
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthors), new { id = author.Id }, author);
        }

        // DELETE author
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

        // PUT request (full update)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author updatedAuthor)
        {
            if (id != updatedAuthor.Id)
            {
                return BadRequest("Author ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAuthor = await _context.Authors.FindAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            existingAuthor.FirstName = updatedAuthor.FirstName;
            existingAuthor.LastName = updatedAuthor.LastName;
            _context.Entry(existingAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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


        // PATCH request (partial update)
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchAuthor(int id, [FromBody] JsonPatchDocument<Author> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(author);


            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(a => a.Id == id);
        }
    }
}
