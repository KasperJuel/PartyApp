using PartyApp.Models;
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
                .Where(p => p.DateTime > DateTime.Now);

            return View(upcomingParties);
        }
    }
}