using PartyApp.Models;
using System;

namespace PartyApp.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalLocation { get; set; }

        public PartyDto Party { get; set; }
    }
}
