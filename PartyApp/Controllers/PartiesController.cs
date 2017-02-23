using Microsoft.AspNet.Identity;
using PartyApp.Models;
using PartyApp.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PartyApp.Controllers
{
    public class PartiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartiesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var parties = _context.Attendances
                    .Where(a => a.AttendeeId == userId)
                    .Select(a => a.Party)
                    .Include(p => p.User)
                    .Include(p => p.PartyType)
                    .ToList();

            var model = new PartiesViewModel()
            {
                UpcomingParties = parties,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Mine Kommende Fester"
            };

            return View("Parties", model);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new PartyFormViewModel
            {
                PartyTypes = _context.PartyTypes.ToList()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartyFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PartyTypes = _context.PartyTypes.ToList();
                return View("Create", model);
            }

            var party = new Party
            {
                UserId = User.Identity.GetUserId(),
                DateTime = model.GetDateTime(),
                PartyTypeId = model.PartyType,
                Location = model.Location
            };

            _context.Parties.Add(party);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}