using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using connString;
using Models.CoreModels;
using AutoMapper;
namespace Services.ScreenService
{
    public class ScreenService:IScreenService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public ScreenService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<ScreenDTO> GetScreens()
        {
            var screens = Database.Fetch<Screen>("SELECT * FROM Screen");
            return Mapper.Map<List<ScreenDTO>>(screens);
        }
        public ScreenDTO GetScreen(int id)
        {
            var query = $"SELECT * FROM Screen WHERE id={id}";
            var screen = Database.Fetch<Screen>(query).FirstOrDefault();
            return Mapper.Map<ScreenDTO>(screen);
        }
        public void PostScreen(ScreenDTO screenDTO)
        {
            string query = @"INSERT INTO Screen(Id,Number,TotalNoOfSeats,ScreenResolution,SoundSystem,TheatreId) VALUES(@Id,@Number,@TotalNoOfSeats,@ScreenResolution,@SoundSystem,@TheatreId)";
            Database.Execute(query, Mapper.Map<Screen>(screenDTO));

        }
        public void PutScreen(int id, ScreenDTO screenDTO)
        {
            string query = @"UPDATE Screen SET Number=@Number,TotalNoOfSeats=@TotalNoOfSeats,ScreenResolution=@ScreenResolution,SoundSystem=@SoundSystem,TheatreId=@TheatreId WHERE Id=@Id";
            Database.Execute(query, Mapper.Map<Screen>(screenDTO));
        }
        public void DeleteScreen(int id)
        {
            string query = $"DELETE Screen WHERE Id={id}";
            Database.Execute(query);
        }
    }
}