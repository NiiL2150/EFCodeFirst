using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<SportSportsman> SportSportsmen { get; set; }
    }
}
