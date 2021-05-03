using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.SeatService
{
    interface ISeatService
    {
        IEnumerable<SeatDTO> GetSeats();
        SeatDTO GetSeat(string number,int screenId);
        void PostSeat(SeatDTO addressDTO);
        void PutSeat(string number,int screenId, SeatDTO addressDTO);
        void DeleteSeat(string number,int screenId);
    }
}
