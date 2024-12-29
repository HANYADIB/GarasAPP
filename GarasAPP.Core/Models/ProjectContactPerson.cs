using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectContactPerson")]
public partial class ProjectContactPerson
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectID")]
    public long ProjectId { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [Column("GovernorateID")]
    public int GovernorateId { get; set; }

    [Column("AreaID")]
    public long? AreaId { get; set; }

    public string Address { get; set; } = null!;

    [StringLength(500)]
    public string ProjectContactPersonName { get; set; } = null!;

    [StringLength(100)]
    public string ProjectContactPersonMobile { get; set; } = null!;

    public bool Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("ProjectContactPeople")]
    public virtual Area? Area { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("ProjectContactPeople")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectContactPersonCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GovernorateId")]
    [InverseProperty("ProjectContactPeople")]
    public virtual Governorate Governorate { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectContactPersonModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectContactPeople")]
    public virtual Project Project { get; set; } = null!;
}
