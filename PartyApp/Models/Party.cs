using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PartyApp.Models
{
    public class Party
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(250)]
        public string Location { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public byte PartyTypeId { get; set; }
        public PartyType PartyType { get; set; }

        public bool IsCanceled { get; private set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Party()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = new Notification(NotificationType.PartyCanceled, this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string location, byte partyType)
        {
            var notification = new Notification(NotificationType.PartyUpdated, this);
            notification.OriginalDateTime = DateTime;
            notification.OriginalLocation = Location;

            Location = location;
            DateTime = dateTime;
            PartyTypeId = partyType;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }
    }
}
