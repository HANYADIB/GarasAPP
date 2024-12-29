using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class Childern
    {
        public int Id { get; set; }
        public int Years { get; set; }
        public int RoomId { get; set; }
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public Room Room { get; set; }
    }
}
