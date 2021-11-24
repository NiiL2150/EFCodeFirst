using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Models
{
    public class Medal
    {
        public int Id { get; set; }
        public MedalType Type { get; set; }
        public virtual ICollection<SportSportsman> SportSportsman { get; set; }
    }

    public enum MedalType
    {
        Gold, Silver, Bronze
    }
}
