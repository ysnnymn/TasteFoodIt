using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteFoodIt.Entities
{
    public class Rezervation
    {
        public int RezervationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RezervationDate { get; set; }
        public string Time { get; set; }
        public byte GuestCount { get; set; }
        public string RezervationStatus { get; set; }

    }
}