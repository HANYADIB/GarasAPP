using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectTM")]
public partial class ProjectTm
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    [StringLength(500)]
    public string Requirement { get; set; } = null!;

    [Column("ClientID")]
    public long ClientId { get; set; }

    public int? Revision { get; set; }

    [Required]
    public bool? Status { get; set; }

    [Column("PriortyID")]
    public int PriortyId { get; set; }

    [StringLength(250)]
    public string? Serial { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    public bool Billable { get; set; }

    [Required]
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

    [ForeignKey("BranchId")]
    [InverseProperty("ProjectTms")]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey("ClientId")]
    [InverseProperty("ProjectTms")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectTmCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("ProjectTm")]
    public virtual ICollection<ManageStage> ManageStages { get; set; } = new List<ManageStage>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectTmModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("PriortyId")]
    [InverseProperty("ProjectTms")]
    public virtual Priority Priorty { get; set; } = null!;

    [InverseProperty("ProjectTm")]
    public virtual ICollection<ProjectTmassignUser> ProjectTmassignUsers { get; set; } = new List<ProjectTmassignUser>();

    [InverseProperty("ProjectTm")]
    public virtual ICollection<ProjectTmattachment> ProjectTmattachments { get; set; } = new List<ProjectTmattachment>();

    [InverseProperty("ProjectTm")]
    public virtual ICollection<ProjectTmimpDate> ProjectTmimpDates { get; set; } = new List<ProjectTmimpDate>();

    [InverseProperty("ProjectTm")]
    public virtual ICollection<ProjectTmsprint> ProjectTmsprints { get; set; } = new List<ProjectTmsprint>();
}
