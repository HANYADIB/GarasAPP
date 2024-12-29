using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models
{
    public class languagee
    {
        [Key]
         public int Id { get; set; }

         public string shortvalue { get; set; }
         public string value { get; set; }
    }
}
