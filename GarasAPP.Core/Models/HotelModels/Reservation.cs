using GarasAPP.Core.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime? reservationDate { get; set; } = DateTime.Now;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        //public lIST<int>  RoomIdS { get; set; }
        //public int NumberOfAdulte { get; set; }

        public long ClientId { get; set; }
       //blic int MealTypeId { get; set; }
       // public int MealRatesId { get; set; }
      // public int ChildId { get; set; }
        public string Provider { get; set; }
        public bool Confirmation { get; set; }

        //public lIST<Room>? Room { get; set; }
        public  Client? Clients { get; set; }
        //public  MealType? mealType { get; set; }
        //public Children? Children { get; set; }
        //public MealRate? MealRate { get; set; }
       // public virtual List<Child>? Child { get; set; }
        //public Rate? Rate { get; set; }

    }

   
}
