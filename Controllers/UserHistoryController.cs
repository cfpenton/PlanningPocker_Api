using System.Linq;
using APIREST_PlanningPocker.Data;
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
    }
}