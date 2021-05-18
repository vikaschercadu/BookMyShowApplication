using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.TheatreService
{
    interface ITheatreService
    {
        IEnumerable<TheatreDTO> GetTheatres();
        TheatreDTO GetTheatre(int id);
        void PostTheatre(TheatreDTO addressDTO);
        void PutTheatre(int id, TheatreDTO addressDTO);
        void DeleteTheatre(int id);
    }
}
