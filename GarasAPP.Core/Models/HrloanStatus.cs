using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("HRLoanStatus")]
public partial class HrloanStatus
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    [InverseProperty("LoanStatus")]
    public virtual ICollection<Hrloan> Hrloans { get; set; } = new List<Hrloan>();
}
