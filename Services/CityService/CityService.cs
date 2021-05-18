using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.CoreModels;
using AutoMapper;
using connString;
namespace Services.CityService
{
    public class CityService:ICityService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public CityService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<CityDTO> GetCities()
        {
            var cities = Database.Fetch<City>("SELECT * FROM City");
            return Mapper.Map<List<CityDTO>>(cities);
        }
        public CityDTO GetCity(int id)
        {
            var query = $"SELECT * FROM City WHERE id={id}";
            var city = Database.Fetch<City>(query).FirstOrDefault();
            return Mapper.Map<CityDTO>(city);
        }
        public void PostCity(CityDTO cityDTO)
        {
            string query = @"INSERT INTO City(Id,Name,State,Pincode) VALUES(@Id,@Name,@State,@Pincode)";
            Database.Execute(query, Mapper.Map<City>(cityDTO));

        }
        public void PutCity(int id, CityDTO cityDTO)
        {
            string query = @"UPDATE City SET Name=@Name,State=@State,Pincode=@Pincode WHERE Id=@Id";
            Database.Execute(query, Mapper.Map<City>(cityDTO));
        }
        public void DeleteCity(int id)
        {
            string query = $"DELETE City WHERE Id={id}";
            Database.Execute(query);
        }
    }
}