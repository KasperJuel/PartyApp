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

        public ActionResult Create()
        {
            var model = new PartyFormViewModel
            {
                PartyTypes = _context.PartyTypes.ToList()
            };

            return View(model);
        }
    }
}