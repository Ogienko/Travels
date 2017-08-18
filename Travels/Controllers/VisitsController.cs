using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Travels.Common;
using Travels.Common.Models;
using Travels.Common.Models.BaseModels;

namespace Travels.Controllers {

    [Route("[controller]")]
    [Produces("application/json")]
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

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]VisitBase visit) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var _visit = _context.Visits.FirstOrDefault(_ => _.Id == id);

            if (_visit == null) {
                return NotFound();
            }

            _visit.LocationId = visit.LocationId;
            _visit.UserId = visit.UserId;
            _visit.VisitedAt = visit.VisitedAt;
            _visit.Mark = visit.Mark;

            _context.SaveChanges();

            return new JsonResult(new Object());
        }

        [HttpPost("new")]
        public IActionResult Post([FromBody]Visit visit) {

            if (!ModelState.IsValid) {
                return BadRequest();
            }

            _context.Visits.Add(visit);

            _context.SaveChanges();

            return new JsonResult(new Object());
        }
    }
}