using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class AddlistreservationByIDDto
    {
        public string? RoomName { get; set; }
        public string? MealName { get; set; }
        public int? NumAdults { get; set; }
        public int? NumChildern { get; set; }
        public List<int>? YearsofChildern { get; set; }
    }
}
