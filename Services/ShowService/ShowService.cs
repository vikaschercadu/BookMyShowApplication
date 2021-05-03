using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models.CoreModels;
using connString;
namespace Services.ShowService
{
    public class ShowService:IShowService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public ShowService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<ShowDTO> GetShows()
        {
            var shows = Database.Fetch<Show>("SELECT * FROM Show");
            return Mapper.Map<List<ShowDTO>>(shows);
        }
        public ShowDTO GetShow(int id, DateTime showDate)
        {
            var query = $"SELECT * FROM Show WHERE Id={id} AND ShowDate={showDate}";
            var show = Database.Fetch<Show>(query).FirstOrDefault();
            return Mapper.Map<ShowDTO>(show);
        }
        public void PostShow(ShowDTO showDTO)
        {
            string query = @"INSERT INTO Show(Id,ShowDate,StartTime,EndTime,ScreenId,MovieId) VALUES(@Id,@ShowDate,@StartTime,@EndTime,@ScreenId,@MovieId)";
            Database.Execute(query, Mapper.Map<Show>(showDTO));

        }
        public void PutShow(int id, DateTime showDate, ShowDTO showDTO)
        {
            string query = @"UPDATE Show SET StartTime=@StartTime,EndTime=@EndTime,ScreenId=@ScreenId,MovieId=@MovieId WHERE Id=@id ShowDate=@showDate";
            Database.Execute(query, Mapper.Map<Show>(showDTO));
        }
        public void DeleteShow(int id, DateTime showDate)
        {
            string query = $"DELETE Show WHERE Id={id} AND ShowDate={showDate}";
            Database.Execute(query);
        }
    }
}