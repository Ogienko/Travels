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

        [HttpGet("{id}/visits")]
        public IActionResult GetUserVisits(int id, [FromQuery]GetUserVisitsParameters parameters) {

            var user = _context.Users.FirstOrDefault(_ => _.Id == id);

            if (user == null) {
                return NotFound();
            }

            var query = _context.Visits.Where(_ => _.UserId == id).Join(_context.Locations, visit => visit.LocationId, location => location.Id, (visit, location) => new {
                VisitedAt = visit.VisitedAt,
                Mark = visit.Mark,
                Place = location.Place,
                Country = location.Country,
                Distance = location.Distance
            });

            if (parameters.FromDate.HasValue) {
                query = query.Where(_ => _.VisitedAt > parameters.FromDate);
            }

            if (parameters.ToDate.HasValue) {
                query = query.Where(_ => _.VisitedAt < parameters.ToDate);
            }

            if (!String.IsNullOrEmpty(parameters.Country)) {
                query = query.Where(_ => _.Country == parameters.Country);
            }

            if (parameters.ToDistance.HasValue) {
                query = query.Where(_ => _.Distance < parameters.ToDistance);
            }

            var result = query.Select(_ => new {
                Mark = _.Mark,
                VisitedAt = _.VisitedAt,
                Place = _.Place
            }).OrderBy(_ => _.VisitedAt).ToList();

            return new JsonResult(result);
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