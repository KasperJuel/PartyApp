using Microsoft.AspNet.Identity;
using PartyApp.Models;
using PartyApp.ViewModels;
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
        public ActionResult Create(PartyFormViewModel model)
        {
            var party = new Party
            {
                UserId = User.Identity.GetUserId(),
                DateTime = model.DateTime,
                PartyTypeId = model.PartyType,
                Location = model.Location
            };

            _context.Parties.Add(party);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}