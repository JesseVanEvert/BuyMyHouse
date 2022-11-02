using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Model.Entities
{
    public class Person
    {
        public Guid PersonID { get; set; }
        public Guid? ApplicationID { get; set; }
        public virtual Application? Application { get; set; }

        public string Email { get; set; }
        public string Firstname { get; set; }
        public string? Prefix { get; set; }
        public string Lastname { get; set; }
        public double YearlyIncomeInEuros { get; set; }
    }
}
