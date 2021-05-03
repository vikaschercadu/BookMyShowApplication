using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.ScreenService
{
    interface IScreenService
    {
        IEnumerable<ScreenDTO> GetScreens();
        ScreenDTO GetScreen(int id);
        void PostScreen(ScreenDTO addressDTO);
        void PutScreen(int id, ScreenDTO addressDTO);
        void DeleteScreen(int id);
    }
}
