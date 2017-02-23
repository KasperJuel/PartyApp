using PartyApp.Models;
using System;
using System.Collections.Generic;

namespace PartyApp.ViewModels
{
    public class PartyFormViewModel
    {
        public string Location { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public byte PartyType { get; set; }

        public IEnumerable<PartyType> PartyTypes { get; set; }

        public DateTime DateTime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
        }
    }
}
