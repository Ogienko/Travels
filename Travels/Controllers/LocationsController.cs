using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Travels.Common;
using Travels.Common.Models;
using Travels.Common.Models.BaseModels;

namespace Travels.Controllers {

    [Route("[controller]")]
    [Produces("application/json")]
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

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]LocationBase location) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var _location = _context.Locations.FirstOrDefault(_ => _.Id == id);

            if (_location == null) {
                return NotFound();
            }

            _location.Place = location.Place;
            _location.Country = location.Country;
            _location.City = location.City;
            _location.Distance = location.Distance;

            _context.SaveChanges();

            return new JsonResult(new Object());
        }

        [HttpPost("new")]
        public IActionResult Post([FromBody]Location location) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            _context.Locations.Add(location);

            _context.SaveChanges();

            return new JsonResult(new Object());
        }
    }
}