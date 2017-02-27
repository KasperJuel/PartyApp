using System;
using System.ComponentModel.DataAnnotations;

namespace PartyApp.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalLocation { get; set; }

        [Required]
        public Party Party { get; private set; }

        public Notification()
        {
        }

        public Notification(NotificationType type, Party party)
        {
            if (party == null)
                throw new ArgumentNullException("party");

            Type = type;
            Party = party;
            DateTime = DateTime.Now;
        }
    }
}
