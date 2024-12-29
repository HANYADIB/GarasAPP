using GarasAPP.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        [FeatureDate]
        public DateTime FromDate { get; set; }
        [FeatureDate]
        public DateTime ToDate { get; set; }
        public List<AddListofReservationDto> ListRooms { get; set; }
        public long ClientId { get; set; }
        public string Provider { get; set; }
        public bool Confirmation { get; set; }
    }
}
