using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("MaintenanceFor")]
public partial class MaintenanceFor
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public string? ProductType { get; set; }

    public string? ProductSerial { get; set; }

    public int? NumOfVisitsPerProduct { get; set; }

    [Column("ProjectID")]
    public long ProjectId { get; set; }

    [Column("FabOrderID")]
    public int? FabOrderId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductBrand { get; set; }

    public string? ProductFabricator { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("VichealID")]
    public long? VichealId { get; set; }

    [Column("SalesOfferID")]
    public long SalesOfferId { get; set; }

    [Column("ClientID")]
    public long ClientId { get; set; }

    public long? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    [Column("InventoryItemID")]
    public long? InventoryItemId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("MaintenanceFors")]
    public virtual InventoryItemCategory? Category { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("MaintenanceFors")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("InventoryItemId")]
    [InverseProperty("MaintenanceFors")]
    public virtual InventoryItem? InventoryItem { get; set; }

    [InverseProperty("MaintenanceFor")]
    public virtual ICollection<ManagementOfMaintenanceOrder> ManagementOfMaintenanceOrders { get; set; } = new List<ManagementOfMaintenanceOrder>();

    [ForeignKey("ProjectId")]
    [InverseProperty("MaintenanceFors")]
    public virtual Project Project { get; set; } = null!;

    [ForeignKey("SalesOfferId")]
    [InverseProperty("MaintenanceFors")]
    public virtual SalesOffer SalesOffer { get; set; } = null!;

    [InverseProperty("MaintenanceFor")]
    public virtual ICollection<VisitsScheduleOfMaintenance> VisitsScheduleOfMaintenances { get; set; } = new List<VisitsScheduleOfMaintenance>();
}
