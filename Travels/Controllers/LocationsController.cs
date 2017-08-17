using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Travels.Common;

namespace Travels.Controllers {

    [Produces("application/json")]
    [Route("api/Locations")]
    public class LocationsController : Controller {

        private TravelsContext _context;

        public LocationsController(TravelsContext context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            var location = _context.Locations.FirstOrDefault(_ => _.Id == id);

            if (location == null) {
                return NotFound();
            }

            return new JsonResult(location);
        }
    }
}