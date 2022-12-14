using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Model.Entities
{
    public class Application
    {
        public Guid ApplicationID { get; set; }
        public Guid HouseID { get; set; }
        public House House { get; set; }
        public DateTime AppliedAt { get; set; }

        public virtual ICollection<Person> Applicants { get; set; }
    }
}
