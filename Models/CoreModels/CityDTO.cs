using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models.CoreModels
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}