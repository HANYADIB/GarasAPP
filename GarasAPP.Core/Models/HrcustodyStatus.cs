using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("HRCustodyStatus")]
public partial class HrcustodyStatus
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string Status { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Hrcustody> Hrcustodies { get; set; } = new List<Hrcustody>();
}
