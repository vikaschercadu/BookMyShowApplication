using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models.CoreModels
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string Landmark { get; set; }
        public int CityId { get; set; }
    }
}