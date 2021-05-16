using System.Linq;
using APIREST_PlanningPocker.Data;
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
    }
}