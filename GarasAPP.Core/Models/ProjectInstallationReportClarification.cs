﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectInstallationReportClarification")]
public partial class ProjectInstallationReportClarification
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectInstallationReportID")]
    public long ProjectInstallationReportId { get; set; }

    [StringLength(500)]
    public string ClarificationType { get; set; } = null!;

    public string Clarification { get; set; } = null!;

    [Column("ClarificationUserID")]
    public long ClarificationUserId { get; set; }

    public string? FeedBack { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("ClarificationUserId")]
    [InverseProperty("ProjectInstallationReportClarificationClarificationUsers")]
    public virtual User ClarificationUser { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectInstallationReportClarificationCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifedBy")]
    [InverseProperty("ProjectInstallationReportClarificationModifedByNavigations")]
    public virtual User? ModifedByNavigation { get; set; }

    [ForeignKey("ProjectInstallationReportId")]
    [InverseProperty("ProjectInstallationReportClarifications")]
    public virtual ProjectInstallationReport ProjectInstallationReport { get; set; } = null!;

    [InverseProperty("ProjectInstallationReportClarification")]
    public virtual ICollection<ProjectInstallationReportClarificationAttachment> ProjectInstallationReportClarificationAttachments { get; set; } = new List<ProjectInstallationReportClarificationAttachment>();
}