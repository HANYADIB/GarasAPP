using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectFabricationReportClarificationAttachment")]
public partial class ProjectFabricationReportClarificationAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectFabricationReportClarificationID")]
    public long ProjectFabricationReportClarificationId { get; set; }

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

    [StringLength(1000)]
    public string? Description { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectFabricationReportClarificationAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectFabricationReportClarificationAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProjectFabricationReportClarificationId")]
    [InverseProperty("ProjectFabricationReportClarificationAttachments")]
    public virtual ProjectFabricationReportClarification ProjectFabricationReportClarification { get; set; } = null!;
}
