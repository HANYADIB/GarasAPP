using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class RoomsReservationChildern
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public int NumbersofAdulte { get; set; }

        public Reservation Reservation { get; set; }

        public Room Room { get; set; }
        //public List<Childern> Childern { get; set; } 
    }
}
