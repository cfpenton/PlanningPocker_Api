using System.Linq;
using APIREST_PlanningPocker.Data;
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
    }
}