using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("VehicleMaintenanceJobOrderHistory")]
public partial class VehicleMaintenanceJobOrderHistory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long VehicleMaintenanceTypeId { get; set; }

    public long JobOrderProjectId { get; set; }

    public long VehiclePerClientId { get; set; }

    public int? Milage { get; set; }

    public long? NextVisitForId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextVisitDate { get; set; }

    public int? NextVisitMilage { get; set; }

    public string? NextVisitComment { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("JobOrderProjectId")]
    [InverseProperty("VehicleMaintenanceJobOrderHistories")]
    public virtual Project JobOrderProject { get; set; } = null!;

    [ForeignKey("NextVisitForId")]
    [InverseProperty("VehicleMaintenanceJobOrderHistoryNextVisitFors")]
    public virtual VehicleMaintenanceType? NextVisitFor { get; set; }

    [ForeignKey("VehicleMaintenanceTypeId")]
    [InverseProperty("VehicleMaintenanceJobOrderHistoryVehicleMaintenanceTypes")]
    public virtual VehicleMaintenanceType VehicleMaintenanceType { get; set; } = null!;

    [ForeignKey("VehiclePerClientId")]
    [InverseProperty("VehicleMaintenanceJobOrderHistories")]
    public virtual VehiclePerClient VehiclePerClient { get; set; } = null!;
}
