using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.MovieTicketService
{
    interface IMovieTicketService
    {
        IEnumerable<MovieTicketDTO> GetMovieTickets();
        MovieTicketDTO GetMovieTicket(int id);
        void PostMovieTicket(MovieTicketDTO addressDTO);
        void PutMovieTicket(int id, MovieTicketDTO addressDTO);
        void DeleteMovieTicket(int id);
    }
}
