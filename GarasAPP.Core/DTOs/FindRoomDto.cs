using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class FindRoomDto
    {
        public string? Name { get; set; }
        public string? RoomType { get; set; }
        public string? Building { get; set; }
        public string? RoomView { get; set; }
        public List<int>?  Facilties { get; set; }
        public bool FilterByReserved { get; set; }
        public bool Reserved { get; set; }
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime? ToDate { get; set; }

    }
}
