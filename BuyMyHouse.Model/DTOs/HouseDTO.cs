using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Model.DTOs
{
    public class HouseDTO
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string Location { get; set; }
        public double AskingPrice { get; set; }
    }
}
