using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("VisitsScheduleOfMaintenanceAttachment")]
public partial class VisitsScheduleOfMaintenanceAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("VisitsScheduleOfMaintenanceID")]
    public long VisitsScheduleOfMaintenanceId { get; set; }

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool Active { get; set; }

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtenssion { get; set; } = null!;

    [StringLength(250)]
    public string? Category { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("VisitsScheduleOfMaintenanceAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("VisitsScheduleOfMaintenanceAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("VisitsScheduleOfMaintenanceId")]
    [InverseProperty("VisitsScheduleOfMaintenanceAttachments")]
    public virtual VisitsScheduleOfMaintenance VisitsScheduleOfMaintenance { get; set; } = null!;
}
