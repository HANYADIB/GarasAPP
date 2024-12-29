using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskInfoRevision")]
public partial class TaskInfoRevision
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("TaskInfoID")]
    public long TaskInfoId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string? Descreption { get; set; }

    public string? Requirement { get; set; }

    [Column("TaskCategoryID")]
    public long TaskCategoryId { get; set; }

    [Column("TaskPrimarySubCategoryID")]
    public long TaskPrimarySubCategoryId { get; set; }

    public long TaskSecondraySubCategory { get; set; }

    public int Revision { get; set; }

    public bool Status { get; set; }

    [Column("ProiorityID")]
    public int ProiorityId { get; set; }

    [Column("MangageStageID")]
    [StringLength(10)]
    public string MangageStageId { get; set; } = null!;

    public bool NoPermision { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [StringLength(50)]
    public string EstimateDate { get; set; } = null!;

    public bool? Billable { get; set; }

    public bool? TimeTracking { get; set; }

    [Column("EApproval")]
    public bool? Eapproval { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? PercentTime { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? PercentQuality { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? PercentPerformance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ClousereDate { get; set; }

    [StringLength(50)]
    public string? TotalTime { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TaskInfoRevisionCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TaskInfoRevisionModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("ProiorityId")]
    [InverseProperty("TaskInfoRevisions")]
    public virtual Priority Proiority { get; set; } = null!;

    [ForeignKey("TaskCategoryId")]
    [InverseProperty("TaskInfoRevisions")]
    public virtual TaskCategory TaskCategory { get; set; } = null!;
}
