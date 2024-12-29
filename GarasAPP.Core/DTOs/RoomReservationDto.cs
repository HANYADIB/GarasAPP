using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class RoomReservationDto
    {
        public Room Room { get; set; }
        public List<ReservationGridDto> reservations { get; set; }
        public List<RateDto> rate { get; set; }
        //public byte? SpecialOfferFlag { get; set; }
        //public DateTime? StartingDate { get; set; }
        //public DateTime? EndingDate { get; set; }

    }
}
