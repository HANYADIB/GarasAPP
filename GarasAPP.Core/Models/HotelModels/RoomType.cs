﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class RoomType
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
