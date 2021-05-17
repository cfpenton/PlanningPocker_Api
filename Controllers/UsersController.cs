using System.Linq;
using System.Threading.Tasks;
using APIREST_PlanningPocker.Data;
using APIREST_PlanningPocker.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIREST_PlanningPocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DataContext _context = null;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        /* api/users */
        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_context.users.ToList());
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users users)
        {
            _context.users.Add(users);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetUsers), new { id = users.Id }, users);
        }
    }
}