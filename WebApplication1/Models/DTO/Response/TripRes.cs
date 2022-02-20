using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DTO.Response
{
    public class TripRes
    {
      //  public int IdTrip { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public List<ClientRes> Clients { get; set; }
        public List<CountryRes> Countries { get; set; }
    }
}
