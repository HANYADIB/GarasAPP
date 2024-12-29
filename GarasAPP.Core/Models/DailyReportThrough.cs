using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("DailyReportThrough")]
public partial class DailyReportThrough
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifedDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("DailyReportThroughCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("DailyReportThrough")]
    public virtual ICollection<DailyReportLine> DailyReportLines { get; set; } = new List<DailyReportLine>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("DailyReportThroughModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
