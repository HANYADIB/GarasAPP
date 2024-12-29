using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Department")]
public partial class Department
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Departments")]
    public virtual Branch Branch { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<BranchDepartment> BranchDepartments { get; set; } = new List<BranchDepartment>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("DepartmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<JobInformation> JobInformations { get; set; } = new List<JobInformation>();

    [InverseProperty("Department")]
    public virtual ICollection<MaintenanceReportUser> MaintenanceReportUsers { get; set; } = new List<MaintenanceReportUser>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("DepartmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<ProjectFabricationReportUser> ProjectFabricationReportUsers { get; set; } = new List<ProjectFabricationReportUser>();

    [InverseProperty("Department")]
    public virtual ICollection<ProjectInstallationReportUser> ProjectInstallationReportUsers { get; set; } = new List<ProjectInstallationReportUser>();

    [InverseProperty("Department")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
