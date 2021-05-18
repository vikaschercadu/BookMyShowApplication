using System;
using Models.Enums;
namespace Models.CoreModels
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