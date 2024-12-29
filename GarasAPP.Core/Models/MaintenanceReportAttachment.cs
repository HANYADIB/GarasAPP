using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("MaintenanceReportAttachment")]
public partial class MaintenanceReportAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("MaintenanceReportID")]
    public long MaintenanceReportId { get; set; }

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtenssion { get; set; } = null!;

    [StringLength(250)]
    public string? Category { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("MaintenanceReportAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("MaintenanceReportId")]
    [InverseProperty("MaintenanceReportAttachments")]
    public virtual MaintenanceReport MaintenanceReport { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("MaintenanceReportAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
