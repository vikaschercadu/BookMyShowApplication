using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models.CoreModels;
using connString;
namespace Services.TheatreService
{
    public class TheatreService:ITheatreService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public TheatreService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<TheatreDTO> GetTheatres()
        {
            var theatres = Database.Fetch<Theatre>("SELECT * FROM Theatre");
            return Mapper.Map<List<TheatreDTO>>(theatres);
        }
        public TheatreDTO GetTheatre(int id)
        {
            var query = $"SELECT * FROM Theatre WHERE id={id}";
            var theatre = Database.Fetch<Theatre>(query).FirstOrDefault();
            return Mapper.Map<TheatreDTO>(theatre);
        }
        public void PostTheatre(TheatreDTO theatreDTO)
        {
            string query = @"INSERT INTO Theatre(Id,Name,NoOfScreens,IsParkingAvailable,AddressId) VALUES(@Id,@Name,@NoOfScreens,@IsParkingAvailable,@AddressId)";
            Database.Execute(query, Mapper.Map<Theatre>(theatreDTO));

        }
        public void PutTheatre(int id, TheatreDTO theatreDTO)
        {
            string query = @"UPDATE Theatre SET Name@Name,NoOfScreens=@NoOfScreens,IsParkingAvailable=@IsParkingAvailable,AddressId=@AddressId WHERE Id=@id";
            Database.Execute(query, Mapper.Map<Theatre>(theatreDTO));
        }
        public void DeleteTheatre(int id)
        {
            string query = $"DELETE Theatre WHERE Id={id}";
            Database.Execute(query);
        }
    }
}