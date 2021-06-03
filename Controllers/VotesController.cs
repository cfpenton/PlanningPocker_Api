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
    public class VotesController : ControllerBase
    {
        private DataContext _context = null;

        public VotesController(DataContext context)
        {
            _context = context;
        }

        /* GET: api/votes */
        [HttpGet]
        public ActionResult GetVotes()
        {
            return Ok(_context.votes.ToList());
        }

        /* POST: api/votes */
        [HttpPost]
        public async Task<ActionResult<Votes>> PostVote(Votes votes)
        {
            _context.votes.Add (votes);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetVotes),
            new { id = votes.Id },
            votes);
        }

        /* GET: api/votes/{id}*/
        [HttpGet("{id}")]
        public async Task<ActionResult<Votes>> GetVotoById(int id)
        {
            var votes = await _context.votes.FindAsync(id);

            if (votes == null)
            {
                return NotFound();
            }

            return votes;
        }

        /* PUT: api/votes/{id} */
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVote(int id, Votes votes)
        {
            if (id != votes.Id)
            {
                return BadRequest();
            }

            _context.Entry(votes).State = EntityState.Modified;
            var evote = await _context.votes.FindAsync(id);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (evote == null)
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

        // DELETE: api/votes/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVoto(int id)
        {
            var voto = await _context.votes.FindAsync(id);
            if (voto == null)
            {
                return NotFound();
            }

            _context.votes.Remove (voto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
