
using System.Collections.Generic;

#nullable disable
namespace WebApplication1.Models
{
    public class Country
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public virtual HashSet<CountryTrip> CountryTrip { get; set; }

        public Country()
        {
            CountryTrip = new HashSet<CountryTrip>();
        }

    }
}
