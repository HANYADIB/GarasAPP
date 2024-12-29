using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectFinishInstallationAttachment")]
public partial class ProjectFinishInstallationAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectInstallationReportID")]
    public long ProjectInstallationReportId { get; set; }

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

    [Column(TypeName = "datetime")]
    public DateTime? StartIn { get; set; }

    public int? Period { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndIn { get; set; }

    public bool? FinalReport { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectFinishInstallationAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectFinishInstallationAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProjectInstallationReportId")]
    [InverseProperty("ProjectFinishInstallationAttachments")]
    public virtual ProjectInstallationReport ProjectInstallationReport { get; set; } = null!;
}
