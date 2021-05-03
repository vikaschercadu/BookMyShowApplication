using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using connString;
using Models.CoreModels;
using AutoMapper;
namespace Services.MovieService
{
    public class MovieService:IMovieService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public MovieService(IMapper mapper, PetaPoco.Database database)
        {
            Database = database;
            Mapper = mapper;
        }
        public IEnumerable<MovieDTO> GetMovies()
        {
            var movies = Database.Fetch<Movie>("SELECT * FROM Movie");
            return Mapper.Map<List<MovieDTO>>(movies);
        }
        public MovieDTO GetMovie(int id)
        {
            var query = $"SELECT * FROM Movie WHERE id={id}";
            var movie = Database.Fetch<Movie>(query).FirstOrDefault();
            return Mapper.Map<MovieDTO>(movie);
        }
        public void PostMovie(MovieDTO movieDTO)
        {
            string query = @"INSERT INTO Movie(Id,Title,Language,Genre,RunningTime,ReleaseDate,ImageUrl) VALUES(@Id,@Title,@Language,@Genre,@RunningTime,@ReleaseDate,@ImageUrl)";
            Database.Execute(query, Mapper.Map<Movie>(movieDTO));

        }
        public void PutMovie(int id, MovieDTO movieDTO)
        {
            string query = @"UPDATE Movie SET Title=@Title,Language=@Language,Genre=@Genre,RunningTime=@RunningTime,ReleaseDate=@ReleaseDate,ImageUrl=@ImageUrl WHERE Id=@Id";
            Database.Execute(query, Mapper.Map<Movie>(movieDTO));
        }
        public void DeleteMovie(int id)
        {
            string query = $"DELETE Movie WHERE Id={id}";
            Database.Execute(query);
        }
    }
}