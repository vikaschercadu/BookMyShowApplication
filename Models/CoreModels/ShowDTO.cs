using System;
namespace Models.CoreModels
{
    public class ShowDTO
    {
		public int Id { get; set; }
		public DateTime ShowDate { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public int ScreenId { get; set; }
		public int MovieId { get; set; }
	}
}