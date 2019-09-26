using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNet6Vjezba.Models
{
    public class TruckContext:DbContext
    {
        public  DbSet<Truck>Trucks { get; set; }
    }
}