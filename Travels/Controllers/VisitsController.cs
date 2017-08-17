using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Travels.Common;

namespace Travels.Controllers {

    [Produces("application/json")]
    [Route("[controller]")]
    public class VisitsController : Controller {

        private TravelsContext _context;

        public VisitsController(TravelsContext context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            var visit = _context.Visits.FirstOrDefault(_ => _.Id == id);

            if (visit == null) {
                return NotFound();
            }

            return new JsonResult(visit);
        }
    }
}