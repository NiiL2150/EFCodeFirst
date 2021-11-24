using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Models
{
    public class Sportsman
    {
        public int SportsmanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<SportSportsman> SportSportsmen { get; set; }
    }
}
