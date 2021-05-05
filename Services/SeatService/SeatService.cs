using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models.CoreModels;
using connString;
namespace Services.SeatService
{
    public class SeatService:ISeatService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public SeatService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<SeatDTO> GetSeats()
        {
            var seats = Database.Fetch<Seat>("SELECT * FROM Seat");
            return Mapper.Map<List<SeatDTO>>(seats);
        }
        public SeatDTO GetSeat(string number,int screenId)
        {
            var query = $"SELECT * FROM Seat WHERE Number={number} AND ScreenId={screenId}";
            var seat = Database.Fetch<Seat>(query).FirstOrDefault();
            return Mapper.Map<SeatDTO>(seat);
        }
        public void PostSeat(SeatDTO seatDTO)
        {
            string query = @"INSERT INTO Seat(Number,ScreenId) VALUES(@Number,@ScreenId)";
            Database.Execute(query, Mapper.Map<Seat>(seatDTO));

        }
        public void PutSeat(string number,int screenId, SeatDTO seatDTO)
        {
            string query = @"UPDATE Seat SET Number=@Number,ScreenId=@ScreenId WHERE Number=@Number AND ScreenId=@ScreenId";
            Database.Execute(query, Mapper.Map<Seat>(seatDTO));
        }
        public void DeleteSeat(string number,int screenId)
        {
            string query = $"DELETE Seat WHERE Number={number} AND ScreenId={screenId}";
            Database.Execute(query);
        }
    }
}