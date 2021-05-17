using System.Linq;
using System.Threading.Tasks;
using APIREST_PlanningPocker.Data;
using APIREST_PlanningPocker.Models;
using Microsoft.AspNetCore.Mvc;

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
        /* api/votes */
        [HttpGet]
        public ActionResult GetVotes()
        {
            return Ok(_context.votes.ToList());
        }

        // POST: api/votes
        [HttpPost]
        public async Task<ActionResult<Votes>> PostVote(Votes votes)
        {
            _context.votes.Add(votes);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetVotes), new { id = votes.Id }, votes);
        }
    }
}