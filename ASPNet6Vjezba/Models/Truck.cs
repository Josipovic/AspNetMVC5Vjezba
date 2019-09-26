using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNet6Vjezba.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public float Consumption { get; set; }
        public bool Available { get; set; }
        public int TraveledKilometers { get; set; }
        public int Capacity { get; set; }
        public float Height { get; set; }
    }
}