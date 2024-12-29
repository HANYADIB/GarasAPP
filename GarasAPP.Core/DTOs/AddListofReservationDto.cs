using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class AddListofReservationDto
    {
        public int RoomId { get; set; }
        public int MealId { get; set; }
        public int NumbersofAud { get; set; }
        public int? NumbersofChildern { get; set; }
        public List<int>? Years { get; set; }
    }
}
