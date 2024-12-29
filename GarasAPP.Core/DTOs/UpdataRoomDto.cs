using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.DTOs
{
    public class UpdataRoomDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int RoomTypeId { get; set; }
        public int BuildingId { get; set; }
        public int RoomViewId { get; set; }
        public string Description { get; set; }
        //public RoomType? RoomType { get; set; }
        //public Building? Building { get; set; }
        //public RoomView? RoomView { get; set; }
        public List<int> FacilitiesIds { get; set; }
        public int? Rate { get; set; }
    }
}
