using System.Linq;
using APIREST_PlanningPocker.Data;
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
    }
}