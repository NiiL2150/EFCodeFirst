using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sportsman> Sportsmen { get; set; }
    }
}
