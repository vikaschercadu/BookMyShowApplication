using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.CityService
{
    interface ICityService
    {
        IEnumerable<CityDTO> GetCities();
        CityDTO GetCity(int id);
        void PostCity(CityDTO cityDTO);
        void PutCity(int id, CityDTO cityDTO);
        void DeleteCity(int id);
    }
}
