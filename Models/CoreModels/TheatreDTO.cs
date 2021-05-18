
namespace Models.CoreModels
{
    public class TheatreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfScreens { get; set; }
        public bool IsParkingAvailable { get; set; }
        public int AddressId { get; set; }
    }
}