using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models.CoreModels
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
    }
}