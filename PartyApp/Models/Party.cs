using System;
using System.ComponentModel.DataAnnotations;

namespace PartyApp.Models
{
    public class Party
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(250)]
        public string Location { get; set; }

        [Required]
        public PartyType PartyType { get; set; }
    }
}
