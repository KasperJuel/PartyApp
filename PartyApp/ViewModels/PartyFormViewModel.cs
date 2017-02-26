using FindFesten.ViewModels;
using PartyApp.Controllers;
using PartyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace PartyApp.ViewModels
{
    public class PartyFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte PartyType { get; set; }

        public IEnumerable<PartyType> PartyTypes { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<PartiesController, ActionResult>> update = (c => c.Update(this));

                Expression<Func<PartiesController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
