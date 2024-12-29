using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models.HotelModels
{
    public class Nationality
    {
        [Key]
        public int num_code { get; set; }
        public string alpha_2_code { get; set; }
        public string alpha_3_code { get; set; }
        public string en_short_name { get; set; }
        public string nationality { get; set; }
    }
}
