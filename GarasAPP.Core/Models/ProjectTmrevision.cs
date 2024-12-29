using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectTMRevision")]
public partial class ProjectTmrevision
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectTMID")]
    public long ProjectTmid { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string Descreption { get; set; } = null!;

    [StringLength(500)]
    public string Requirment { get; set; } = null!;

    [Column("ClientID")]
    public long ClientId { get; set; }

    public int? Revision { get; set; }

    public bool Status { get; set; }

    [Column("PriorityID")]
    public int PriorityId { get; set; }

    [StringLength(50)]
    public string? Serial { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    public bool? Billable { get; set; }

    public bool? TimeTracking { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [StringLength(50)]
    public string EstimateTime { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ProjectTmrevisions")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectTmrevisionCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectTmrevisionModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("PriorityId")]
    [InverseProperty("ProjectTmrevisions")]
    public virtual Priority Priority { get; set; } = null!;
}
