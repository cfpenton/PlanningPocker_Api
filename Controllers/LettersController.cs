using System.Linq;
using System.Threading.Tasks;
using APIREST_PlanningPocker.Data;
using APIREST_PlanningPocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIREST_PlanningPocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LettersController : ControllerBase
    {
        private DataContext _context = null;

        public LettersController(DataContext context)
        {
            _context = context;
        }

        /* GET: api/letters */
        [HttpGet]
        public ActionResult GetLetters()
        {
            return Ok(_context.letters.ToList());
        }

        /* POST: api/letters */
        [HttpPost]
        public async Task<ActionResult<Letters>> PostLetter(Letters letters)
        {
            _context.letters.Add (letters);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLetters),
            new { id = letters.Id },
            letters);
        }

        /* GET: api/letters/{id}*/
        [HttpGet("{id}")]
        public async Task<ActionResult<Letters>> GetLetterById(int id)
        {
            var letters = await _context.letters.FindAsync(id);

            if (letters == null)
            {
                return NotFound();
            }

            return letters;
        }

        /* PUT: api/letters/{id} */
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLetter(int id, Letters letters)
        {
            if (id != letters.Id)
            {
                return BadRequest();
            }

            _context.Entry(letters).State = EntityState.Modified;
            var eletter = await _context.letters.FindAsync(id);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (eletter == null)
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

        /* DELETE: api/letters/{id} */
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLetter(int id)
        {
            var letter = await _context.letters.FindAsync(id);
            if (letter == null)
            {
                return NotFound();
            }

            _context.letters.Remove (letter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
