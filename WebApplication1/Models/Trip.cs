using System;
using System.Collections.Generic;
#nullable disable
namespace WebApplication1.Models
{
    public class Trip
    {
        public int IdTrip { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }

        public DateTime Dateto { get; set; }
        public int MaxPeople { get; set; }
        public virtual HashSet<ClientTrip> CleintTrips{ get; set; }
        public virtual HashSet<CountryTrip> CountryTrips { get; set; }

        public Trip()
        {
            CleintTrips = new HashSet<ClientTrip>();
            CountryTrips = new HashSet<CountryTrip>();
        }
}
}