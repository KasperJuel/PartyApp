using System;
using System.ComponentModel.DataAnnotations;

namespace PartyApp.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalLocation { get; private set; }

        [Required]
        public Party Party { get; private set; }

        public Notification()
        {
        }

        private Notification(NotificationType type, Party party)
        {
            if (party == null)
                throw new ArgumentNullException("party");

            Type = type;
            Party = party;
            DateTime = DateTime.Now;
        }

        public static Notification PartyCreated(Party party)
        {
            return new Notification(NotificationType.PartyCreated, party);
        }

        public static Notification PartyUpdated(Party newParty, DateTime originalDateTime, string originalLocation)
        {
            var notification = new Notification(NotificationType.PartyUpdated, newParty);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalLocation = originalLocation;

            return notification;
        }

        public static Notification PartyCanceled(Party party)
        {
            return new Notification(NotificationType.PartyCanceled, party);
        }
    }
}
