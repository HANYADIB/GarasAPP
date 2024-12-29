using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("VehicleMaintenanceTypeServiceSheduleCategory")]
public partial class VehicleMaintenanceTypeServiceSheduleCategory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long VehicleServiceScheduleCategoryId { get; set; }

    public long VehicleMaintenanceTypeId { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long CreatedBy { get; set; }

    [ForeignKey("VehicleMaintenanceTypeId")]
    [InverseProperty("VehicleMaintenanceTypeServiceSheduleCategories")]
    public virtual VehicleMaintenanceType VehicleMaintenanceType { get; set; } = null!;

    [ForeignKey("VehicleServiceScheduleCategoryId")]
    [InverseProperty("VehicleMaintenanceTypeServiceSheduleCategories")]
    public virtual VehicleServiceScheduleCategory VehicleServiceScheduleCategory { get; set; } = null!;
}
