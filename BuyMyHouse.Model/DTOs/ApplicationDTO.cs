using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Model.DTOs
{
    public class ApplicationDTO
    {
        public Guid ApplicantOneID { get; set; }

        //If the applicant has a partner for example
        public Guid? ApplicantTwoID { get; set; }
        public Guid HouseID { get; set; }
    }
}
