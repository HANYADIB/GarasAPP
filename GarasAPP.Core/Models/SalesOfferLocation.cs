using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferLocation")]
public partial class SalesOfferLocation
{
    [Key]
    public long Id { get; set; }

    public long SalesOfferId { get; set; }

    public int? CountryId { get; set; }

    public int? GovernorateId { get; set; }

    [Column("AreaID")]
    public long? AreaId { get; set; }

    [StringLength(10)]
    public string? BuildingNumber { get; set; }

    [StringLength(10)]
    public string? Floor { get; set; }

    public string? Street { get; set; }

    public string? Description { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? LocationX { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? LocationY { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(250)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(250)]
    public string ModifiedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("SalesOfferLocations")]
    public virtual Area? Area { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("SalesOfferLocations")]
    public virtual Country? Country { get; set; }

    [ForeignKey("GovernorateId")]
    [InverseProperty("SalesOfferLocations")]
    public virtual Governorate? Governorate { get; set; }

    [ForeignKey("SalesOfferId")]
    [InverseProperty("SalesOfferLocations")]
    public virtual SalesOffer SalesOffer { get; set; } = null!;
}
