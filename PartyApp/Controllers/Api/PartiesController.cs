using Microsoft.AspNet.Identity;
using PartyApp.Models;
using System.Linq;
using System.Web.Http;

namespace PartyApp.Controllers.Api
{
    [Authorize]
    public class PartiesController : ApiController
    {
        private ApplicationDbContext _context;

        public PartiesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var party = _context.Parties.Single(p => p.Id == id && p.UserId == userId);

            party.IsCanceled = true;

            _context.SaveChanges();

            return Ok();
        }
    }
}
