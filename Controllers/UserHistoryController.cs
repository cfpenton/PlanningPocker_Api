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
    public class UserHistoryController : ControllerBase
    {
        private DataContext _context = null;

        public UserHistoryController(DataContext context)
        {
            _context = context;
        }

        /* api/userHistory */
        [HttpGet]
        public ActionResult GetUserHistory()
        {
            return Ok(_context.userHistories.ToList());
        }

        // POST: api/userHistory
        [HttpPost]
        public async Task<ActionResult<UserHistory>>
        PostUserHistorie(UserHistory userHistories)
        {
            _context.userHistories.Add (userHistories);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetUserHistory),
            new { id = userHistories.Id },
            userHistories);
        }

        /* GET: api/userHistory/{id}*/
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHistory>> GetUserHistoryById(int id)
        {
            var userHistories = await _context.userHistories.FindAsync(id);

            if (userHistories == null)
            {
                return NotFound();
            }

            return userHistories;
        }

        /* PUT: api/userHistory/{id} */
        [HttpPut("{id}")]
        public async Task<ActionResult>
        PutUserHistory(int id, UserHistory userHistories)
        {
            if (id != userHistories.Id)
            {
                return BadRequest();
            }

            _context.Entry(userHistories).State = EntityState.Modified;
            var euserHistory = await _context.userHistories.FindAsync(id);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (euserHistory == null)
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

        // DELETE: api/userHistory/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserHistory(int id)
        {
            var userHistory = await _context.userHistories.FindAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }

            _context.userHistories.Remove (userHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
