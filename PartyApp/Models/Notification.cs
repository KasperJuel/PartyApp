using System;
using System.ComponentModel.DataAnnotations;

namespace PartyApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalLocation { get; set; }

        [Required]
        public Party Party { get; set; }
    }
}
