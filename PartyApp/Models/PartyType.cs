using System.ComponentModel.DataAnnotations;

namespace PartyApp.Models
{
    public class PartyType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}