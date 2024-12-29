using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("HRLoanRefundStrategy")]
public partial class HrloanRefundStrategy
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Strategy { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    [InverseProperty("RefundStrategy")]
    public virtual ICollection<Hrloan> Hrloans { get; set; } = new List<Hrloan>();
}
