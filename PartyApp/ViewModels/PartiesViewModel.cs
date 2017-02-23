using PartyApp.Models;
using System.Collections.Generic;

namespace PartyApp.ViewModels
{
    public class PartiesViewModel
    {
        public IEnumerable<Party> UpcomingParties { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}
