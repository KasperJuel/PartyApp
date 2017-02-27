using System;

namespace PartyApp.Dtos
{
    public class PartyDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Location { get; set; }

        public UserDto User { get; set; }

        public PartyTypeDto PartyType { get; set; }

        public bool IsCanceled { get; set; }
    }
}
