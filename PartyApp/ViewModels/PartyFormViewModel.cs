using PartyApp.Models;
using System.Collections.Generic;

namespace PartyApp.ViewModels
{
    public class PartyFormViewModel
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int PartyType { get; set; }
        public IEnumerable<PartyType> PartyTypes { get; set; }
    }
}
