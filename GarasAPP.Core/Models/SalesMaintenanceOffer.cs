using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesMaintenanceOffer")]
public partial class SalesMaintenanceOffer
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("MaintenanceSalesOfferID")]
    public long MaintenanceSalesOfferId { get; set; }

    [Column("LinkedSalesOfferID")]
    public long? LinkedSalesOfferId { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesMaintenanceOfferCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("LinkedSalesOfferId")]
    [InverseProperty("SalesMaintenanceOfferLinkedSalesOffers")]
    public virtual SalesOffer? LinkedSalesOffer { get; set; }

    [ForeignKey("MaintenanceSalesOfferId")]
    [InverseProperty("SalesMaintenanceOfferMaintenanceSalesOffers")]
    public virtual SalesOffer MaintenanceSalesOffer { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesMaintenanceOfferModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
