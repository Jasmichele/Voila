using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class ConnectModel
    {
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Proffesion> Proffesions { get; set; }
        public IEnumerable<Price> Price { get; set; }
        
     
        public int CityId { get; set; }
        public int ProffesionId { get; set; }
        public int PriceId { get; set; }
    }
}