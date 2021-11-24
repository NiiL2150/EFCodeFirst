using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Models
{
    public class SportSportsman
    {
        public int Id { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual Sportsman Sportsman { get; set; }
        public virtual Medal Medal { get; set; } 
    }
}
