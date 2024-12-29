using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Branch")]
public partial class Branch
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(1000)]
    public string Address { get; set; } = null!;

    [StringLength(50)]
    public string? Telephone { get; set; }

    [StringLength(50)]
    public string? Fax { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [Column("GovernorateID")]
    public int GovernorateId { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<BranchDepartment> BranchDepartments { get; set; } = new List<BranchDepartment>();

    [InverseProperty("Branch")]
    public virtual ICollection<BranchProduct> BranchProducts { get; set; } = new List<BranchProduct>();

    [InverseProperty("Branch")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [ForeignKey("CountryId")]
    [InverseProperty("Branches")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BranchCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Branch")]
    public virtual ICollection<Crmreport> Crmreports { get; set; } = new List<Crmreport>();

    [InverseProperty("Branch")]
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    [InverseProperty("Branch")]
    public virtual ICollection<JobInformation> JobInformations { get; set; } = new List<JobInformation>();

    [InverseProperty("Branch")]
    public virtual ICollection<MaintenanceReportUser> MaintenanceReportUsers { get; set; } = new List<MaintenanceReportUser>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("BranchModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<Pricing> Pricings { get; set; } = new List<Pricing>();

    [InverseProperty("Branch")]
    public virtual ICollection<ProjectFabricationReportUser> ProjectFabricationReportUsers { get; set; } = new List<ProjectFabricationReportUser>();

    [InverseProperty("Branch")]
    public virtual ICollection<ProjectInstallationReportUser> ProjectInstallationReportUsers { get; set; } = new List<ProjectInstallationReportUser>();

    [InverseProperty("Branch")]
    public virtual ICollection<ProjectTm> ProjectTms { get; set; } = new List<ProjectTm>();

    [InverseProperty("Branch")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    [InverseProperty("Branch")]
    public virtual ICollection<SalesBranchProductTarget> SalesBranchProductTargets { get; set; } = new List<SalesBranchProductTarget>();

    [InverseProperty("Branch")]
    public virtual ICollection<SalesBranchTarget> SalesBranchTargets { get; set; } = new List<SalesBranchTarget>();

    [InverseProperty("Branch")]
    public virtual ICollection<SalesBranchUserProductTarget> SalesBranchUserProductTargets { get; set; } = new List<SalesBranchUserProductTarget>();

    [InverseProperty("Branch")]
    public virtual ICollection<SalesBranchUserTarget> SalesBranchUserTargets { get; set; } = new List<SalesBranchUserTarget>();

    [InverseProperty("Branch")]
    public virtual ICollection<SalesOffer> SalesOffers { get; set; } = new List<SalesOffer>();

    [InverseProperty("Branch")]
    public virtual ICollection<WorkshopStation> WorkshopStations { get; set; } = new List<WorkshopStation>();
}
