using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
