﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("VisitsScheduleOfMaintenance")]
public partial class VisitsScheduleOfMaintenance
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ManagementOfMaintenanceOrderID")]
    public long? ManagementOfMaintenanceOrderId { get; set; }

    [StringLength(100)]
    public string? Serial { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PlannedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VisitDate { get; set; }

    public bool Status { get; set; }

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column("MaintenanceForID")]
    public long? MaintenanceForId { get; set; }

    [Column("AssignedToID")]
    public long? AssignedToId { get; set; }

    [StringLength(250)]
    public string? MaintenanceVisitType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ConfirmedDate { get; set; }

    public string? ClientProblem { get; set; }

    [ForeignKey("AssignedToId")]
    [InverseProperty("VisitsScheduleOfMaintenanceAssignedTos")]
    public virtual User? AssignedTo { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("VisitsScheduleOfMaintenanceCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("MaintenanceForId")]
    [InverseProperty("VisitsScheduleOfMaintenances")]
    public virtual MaintenanceFor? MaintenanceFor { get; set; }

    [InverseProperty("MaintVisit")]
    public virtual ICollection<MaintenanceReport> MaintenanceReports { get; set; } = new List<MaintenanceReport>();

    [ForeignKey("ManagementOfMaintenanceOrderId")]
    [InverseProperty("VisitsScheduleOfMaintenances")]
    public virtual ManagementOfMaintenanceOrder? ManagementOfMaintenanceOrder { get; set; }

    [ForeignKey("ModifiedBy")]
    [InverseProperty("VisitsScheduleOfMaintenanceModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("VisitsScheduleOfMaintenance")]
    public virtual ICollection<VisitsScheduleOfMaintenanceAttachment> VisitsScheduleOfMaintenanceAttachments { get; set; } = new List<VisitsScheduleOfMaintenanceAttachment>();
}
