﻿using FindFesten.ViewModels;
using PartyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartyApp.ViewModels
{
    public class PartyFormViewModel
    {
        [Required]
        public string Location { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte PartyType { get; set; }

        public IEnumerable<PartyType> PartyTypes { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
