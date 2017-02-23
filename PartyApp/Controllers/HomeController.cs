using PartyApp.Models;
using PartyApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PartyApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingParties = _context.Parties
                .Include(p => p.User)
                .Include(p => p.PartyType)
                .Where(p => p.DateTime > DateTime.Now);

            var model = new PartiesViewModel
            {
                UpcomingParties = upcomingParties,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Kommende Fester"
            };

            return View("Parties", model);
        }
    }
}