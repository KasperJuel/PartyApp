using Microsoft.AspNet.Identity;
using PartyApp.Models;
using PartyApp.ViewModels;
using System;
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
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();

            var parties = _context.Parties
                .Where(p => p.UserId == userId && p.DateTime > DateTime.Now && !p.IsCanceled)
                .Include(pt => pt.PartyType)
                .ToList();

            return View(parties);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new PartyFormViewModel
            {
                PartyTypes = _context.PartyTypes.ToList(),
                Heading = "Opret Fest"
            };

            return View("PartyForm", model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var party = _context.Parties.Single(p => p.Id == id && p.UserId == userId);

            var model = new PartyFormViewModel
            {
                Heading = "Rediger Fest",
                Id = party.Id,
                PartyTypes = _context.PartyTypes.ToList(),
                Date = party.DateTime.ToString("d MMM yyyy"),
                Time = party.DateTime.ToString("HH:mm"),
                PartyType = party.PartyTypeId,
                Location = party.Location
            };

            return View("PartyForm", model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartyFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PartyTypes = _context.PartyTypes.ToList();
                return View("PartyForm", model);
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

            return RedirectToAction("Mine", "Parties");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(PartyFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.PartyTypes = _context.PartyTypes.ToList();
                return View("PartyForm", model);
            }

            var userId = User.Identity.GetUserId();
            var party = _context.Parties
                .Include(p => p.Attendances.Select(a => a.Attendee))
                .Single(p => p.Id == model.Id && p.UserId == userId);

            party.Modify(model.GetDateTime(), model.Location, model.PartyType);

            //party.Location = model.Location;
            //party.DateTime = model.GetDateTime();
            //party.PartyTypeId = model.PartyType;

            _context.SaveChanges();

            return RedirectToAction("Mine", "Parties");
        }
    }
}