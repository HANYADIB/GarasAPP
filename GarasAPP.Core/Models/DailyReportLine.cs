using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("DailyReportLine")]
public partial class DailyReportLine
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("DailyReportID")]
    public long DailyReportId { get; set; }

    [Column("ClientID")]
    public long? ClientId { get; set; }

    [Column("DailyReportThroughID")]
    public int DailyReportThroughId { get; set; }

    [Column("FromTIme")]
    public double? FromTime { get; set; }

    public double? ToTime { get; set; }

    [StringLength(500)]
    public string? Location { get; set; }

    public string? Reason { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public bool? New { get; set; }

    public string? NewClientAddress { get; set; }

    [StringLength(50)]
    public string? NewClientTel { get; set; }

    public bool? Reviewed { get; set; }

    public long? ReviewedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReviewDate { get; set; }

    [StringLength(1000)]
    public string? NewClientName { get; set; }

    [StringLength(500)]
    public string? ContactPerson { get; set; }

    [StringLength(20)]
    public string? ContactPersonMobile { get; set; }

    public int? ReasonTypeId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CustomerSatisfaction { get; set; }

    public string? PickLocation { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("DailyReportLines")]
    public virtual Client? Client { get; set; }

    [ForeignKey("DailyReportId")]
    [InverseProperty("DailyReportLines")]
    public virtual DailyReport DailyReport { get; set; } = null!;

    [InverseProperty("ReportLine")]
    public virtual ICollection<DailyReportAttachment> DailyReportAttachments { get; set; } = new List<DailyReportAttachment>();

    [ForeignKey("DailyReportThroughId")]
    [InverseProperty("DailyReportLines")]
    public virtual DailyReportThrough DailyReportThrough { get; set; } = null!;

    [ForeignKey("ReasonTypeId")]
    [InverseProperty("DailyReportLines")]
    public virtual CrmreportReason? ReasonType { get; set; }
}
