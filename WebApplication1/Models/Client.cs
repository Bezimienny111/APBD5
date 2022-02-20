
using System.Collections.Generic;

#nullable disable
namespace WebApplication1.Models
{
    public class Client
    {
        public int IdClient { get; set; }
        public string FirstName { get;set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string PESEL { get; set; }

        public virtual HashSet<ClientTrip> cTrips { get; set; }

        public Client()
        {
            this.cTrips = new HashSet<ClientTrip>();
        }
    }
}
