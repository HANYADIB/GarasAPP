using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class Rate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public bool IsDefault { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string Currency { get; set; } = "EGP";
        public int RoomRate { get; set; } 
        public int? RoomTypeId { get; set; }
        public int? BuildingId { get; set; }
        public int? RoomViewId { get; set; }
        public byte SpecialOfferFlag { get; set; } = 0;

        public Room? Room { get; set; }
        public RoomType? RoomType { get; set; }
        public Building? Building { get; set; }
        public RoomView? RoomView { get; set; }

    }
}
