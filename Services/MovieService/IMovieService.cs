using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.MovieService
{
    interface IMovieService
    {
        IEnumerable<MovieDTO> GetMovies();
        MovieDTO GetMovie(int id);
        void PostMovie(MovieDTO movieDTO);
        void PutMovie(int id, MovieDTO movieDTO);
        void DeleteMovie(int id);
    }
}
