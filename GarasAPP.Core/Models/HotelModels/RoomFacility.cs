using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class RoomFacility
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int FacilityId { get; set; }

        public Facility Facility { get; set; }

        public Room Room { get; set; }
    }
}
