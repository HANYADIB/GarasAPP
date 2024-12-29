using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Models
{
    public class ClientLanguagee
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public long ClientId { get; set; }
        public virtual Client? Client { get; set; }
        [ForeignKey("Language")]
        public int LanguageeId { get; set; }
        public virtual languagee Languagee { get; set; }
    }
}
