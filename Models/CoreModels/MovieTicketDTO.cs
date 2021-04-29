using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMyShow.Models.Enums;
namespace BookMyShow.Models.CoreModels
{
    public class MovieTicketDTO
    {
		public int Id { get; set; }
		public int UserId { get; set; }
		public string SeatNumber { get; set; }
		public int ShowId { get; set; }
		public DateTime ShowDate { get; set; }
		public int ScreenId { get; set; }
		public SeatStatus Status { get; set; }
		public double TicketPrice { get; set; }
		public double ConvenienceFee { get; set; }
		public double TotalAmount { get; set; }

	}
}