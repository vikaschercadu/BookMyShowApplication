using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.ShowService
{
    interface IShowService
    {
        IEnumerable<ShowDTO> GetShows();
        ShowDTO GetShow(int id,DateTime showDate);
        void PostShow(ShowDTO addressDTO);
        void PutShow(int id, DateTime showDate, ShowDTO addressDTO);
        void DeleteShow(int id, DateTime showDate);
    }
}
