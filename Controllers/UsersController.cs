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
    public class UsersController : ControllerBase
    {
        private DataContext _context = null;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        /* GET: api/users */
        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_context.users.ToList());
        }

        /*  POST: api/users */
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users users)
        {
            _context.users.Add (users);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetUsers),
            new { id = users.Id },
            users);
        }

        /* GET: api/users/{id} */
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var users = await _context.users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        /* PUT: api/users/{id} */
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;
            var euser = await _context.users.FindAsync(id);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (euser == null)
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

        /* DELETE: api/users/{id} */
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove (user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
