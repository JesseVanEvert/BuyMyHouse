using BuyMyHouse.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Model
{
    public class Mortgage
    {
        public Application Application { get; set; }
        public double InterestRate { get; set; }
        public double MaximumLoan { get; set; }
        public double MonthlyPayment { get; set; }
    }
}
