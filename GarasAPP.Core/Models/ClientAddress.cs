using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientAddress")]
public partial class ClientAddress
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ClientID")]
    public long ClientId { get; set; }

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

    [Column("AreaID")]
    public long? AreaId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("ClientAddresses")]
    public virtual Area? Area { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ClientAddresses")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CountryId")]
    [InverseProperty("ClientAddresses")]
    public virtual Country Country { get; set; } = null!;

    //[ForeignKey("CreatedBy")]
    //[InverseProperty("ClientAddressCreatedByNavigations")]
    //public virtual User CreatedByNavigation { get; set; } = null!;

    //[ForeignKey("ModifiedBy")]
    //[InverseProperty("ClientAddressModifiedByNavigations")]
    //public virtual User? ModifiedByNavigation { get; set; }
}
