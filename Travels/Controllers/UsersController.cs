using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Travels.Common;
using Travels.Common.Models;
using Travels.Common.Models.BaseModels;

namespace Travels.Controllers {

    [Route("[controller]")]
    [Produces("application/json")]
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

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]UserBase user) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var _user = _context.Users.FirstOrDefault(_ => _.Id == id);
             
            if (_user == null) {
                return NotFound();
            }

            _user.Email = user.Email;
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Gender = user.Gender;
            _user.BirthDate = user.BirthDate;

            _context.SaveChanges();

            return new JsonResult(new Object());
        }

        [HttpPost("new")]
        public IActionResult Post([FromBody]User user) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            _context.Users.Add(user);

            _context.SaveChanges();

            return new JsonResult(new Object());
        }
    }
}