using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("HRUserWarningActionPlanApproval")]
public partial class HruserWarningActionPlanApproval
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    [InverseProperty("ActionPlanApproval")]
    public virtual ICollection<HruserWarning> HruserWarnings { get; set; } = new List<HruserWarning>();
}
