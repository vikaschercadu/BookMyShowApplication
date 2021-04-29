using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.Models.CoreModels
{
    public class ScreenDTO
    {
		public int Id { get; set; }
		public int Number { get; set; }
		public int TotalNoOfSeats { get; set; }
		public string ScreenResolution { get; set; }
		public string SoundSystem { get; set; }
		public int TheatreId { get; set; }
	}
}