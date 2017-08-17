using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Travels.Common;

namespace Travels.Controllers {

    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller {

        private TravelsContext _context;

        public UsersController(TravelsContext context) {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {

            var user = _context.Users.FirstOrDefault(_ => _.Id == id);

            if (user == null) {
                return NotFound();
            }

            return new JsonResult(user);
        }
    }
}