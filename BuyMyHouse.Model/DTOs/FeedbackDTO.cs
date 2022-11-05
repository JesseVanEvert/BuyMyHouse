using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Model.DTOs
{
    public class FeedbackDTO
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
    }
}
