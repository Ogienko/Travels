using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Travels.Common;
using Travels.Common.Models;
using Travels.Common.Models.BaseModels;
using Travels.Models;

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

        [HttpGet("{id}/avg")]
        public IActionResult GetLocationsAvg(int id, [FromQuery]GetLocationsAvgParameters parameters) {

            var location = _context.Locations.FirstOrDefault(_ => _.Id == id);

            if (location == null) {
                return NotFound();
            }

            var query = _context.Visits.Where(_ => _.LocationId == id).Join(_context.Users, visit => visit.UserId, user => user.Id, (visit, user) => new {
                VisitedAt = visit.VisitedAt,
                Mark = visit.Mark,
                Gender = user.Gender,
                BirthDate = user.BirthDate
            });

            if (parameters.FromDate.HasValue) {
                query = query.Where(_ => _.VisitedAt > parameters.FromDate);
            }

            if (parameters.ToDate.HasValue) {
                query = query.Where(_ => _.VisitedAt < parameters.ToDate);
            }

            var utcNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            if (parameters.FromAge.HasValue) {
                query = query.Where(_ => utcNow - _.BirthDate.Value > parameters.FromAge);
            }

            if (parameters.ToAge.HasValue) {
                query = query.Where(_ => utcNow - _.BirthDate.Value < parameters.ToAge);
            }

            if (!String.IsNullOrEmpty(parameters.Gender)) {
                query = query.Where(_ => _.Gender == parameters.Gender);
            }

            var avg = query.Average(_ => _.Mark);

            var result = avg.HasValue ? avg.Value.ToString("#.#####") : "0";

            return new JsonResult(result);
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