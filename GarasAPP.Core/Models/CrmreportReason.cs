﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("CRMReportReason")]
public partial class CrmreportReason
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(1000)]
    public string Name { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("CrmreportReasonCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("CrmreportReason")]
    public virtual ICollection<Crmreport> Crmreports { get; set; } = new List<Crmreport>();

    [InverseProperty("ReasonType")]
    public virtual ICollection<DailyReportLine> DailyReportLines { get; set; } = new List<DailyReportLine>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("CrmreportReasonModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}