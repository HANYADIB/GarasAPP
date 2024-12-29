using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomTypeId { get; set; }
        public int BuildingId { get; set; }
        public int RoomViewId { get; set; }
       // public lIST<int>? ReservationIdS { get; set; }
        public string Description { get; set; }

        public RoomType? RoomType { get; set; }

        public Building? Building { get; set; }

        public RoomView? RoomView { get; set; }
        //public lIST<Reservation>? Reservation { get; set; }


    }
}
