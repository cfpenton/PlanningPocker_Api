using System.Linq;
using System.Threading.Tasks;
using APIREST_PlanningPocker.Data;
using APIREST_PlanningPocker.Models;
using Microsoft.AspNetCore.Mvc;

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
        /* api/letters */
        [HttpGet]
        public ActionResult GetLetters()
        {
            return Ok(_context.letters.ToList());
        }

        // POST: api/letters
        [HttpPost]
        public async Task<ActionResult<Letters>> PostLetter(Letters letters)
        {
            _context.letters.Add(letters);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetLetters), new { id = letters.Id }, letters);
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
    }
}