using System.Linq;
using System.Threading.Tasks;
using APIREST_PlanningPocker.Data;
using APIREST_PlanningPocker.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<UserHistory>> PostUserHistorie(UserHistory userHistories)
        {
            _context.userHistories.Add(userHistories);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetUserHistory), new { id = userHistories.Id }, userHistories);
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
        
    }
}