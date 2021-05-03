using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models.CoreModels;
using connString;
namespace Services.MovieTicketService
{
    public class MovieTicketService:IMovieTicketService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public MovieTicketService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<MovieTicketDTO> GetMovieTickets()
        {
            var movieTickets = Database.Fetch<MovieTicket>("SELECT * FROM MovieTicket");
            return Mapper.Map<List<MovieTicketDTO>>(movieTickets);
        }
        public MovieTicketDTO GetMovieTicket(int id)
        {
            var query = $"SELECT * FROM MovieTicket WHERE id={id}";
            var movieTicket = Database.Fetch<MovieTicket>(query).FirstOrDefault();
            return Mapper.Map<MovieTicketDTO>(movieTicket);
        }
        public void PostMovieTicket(MovieTicketDTO movieTicketDTO)
        {
            string query = @"INSERT INTO MovieTicket(Id,UserId,SeatNumber,ShowId,ShowDate,ScreenId,Status,TicketPrice,ConvenienceFee,TotalAmount) VALUES(@Id,@UserId,@SeatNumber,@ShowId,@ShowDate,@ScreenId,@Status,@TicketPrice,@ConvenienceFee,@TotalAmount)";
            Database.Execute(query, Mapper.Map<MovieTicket>(movieTicketDTO));

        }
        public void PutMovieTicket(int id, MovieTicketDTO movieTicketDTO)
        {
            string query = @"UPDATE MovieTicket SET UserId=@UserId,SeatNumber=@SeatNumber,ShowId=@ShowId,ShowDate=@ShowDate,ScreenId=@ScreenId,Status=@Status,TicketPrice=@TicketPrice,ConvenienceFee=@ConvenienceFee,TotalAmount=@TotalAmount WHERE Id=@Id";
            Database.Execute(query, Mapper.Map<MovieTicket>(movieTicketDTO));
        }
        public void DeleteMovieTicket(int id)
        {
            string query = $"DELETE MovieTicket WHERE Id={id}";
            Database.Execute(query);
        }
    }
}