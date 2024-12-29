using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientConsultantAddress")]
public partial class ClientConsultantAddress
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ConsultantID")]
    public long ConsultantId { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    [Column("GovernorateID")]
    public int GovernorateId { get; set; }

    public string Address { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(10)]
    public string? BuildingNumber { get; set; }

    [StringLength(10)]
    public string? Floor { get; set; }

    public string? Description { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("ClientConsultantAddresses")]
    public virtual Country Country { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ClientConsultantAddressCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GovernorateId")]
    [InverseProperty("ClientConsultantAddresses")]
    public virtual Governorate Governorate { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ClientConsultantAddressModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
