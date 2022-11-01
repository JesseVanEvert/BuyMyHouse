﻿namespace BuyMyHouse.Model.Entities
{
    public class House
    {
        public Guid HouseID { get; set; }
        public string HouseNumber { get; set; } 
        public string Street { get; set; }  
        public string Postcode { get; set; }
        public string Location { get; set; }
        public double AskingPrice { get; set; }
    }
}