using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("HRCustodyReportAttachment")]
public partial class HrcustodyReportAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("CustodyID")]
    public long CustodyId { get; set; }

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtension { get; set; } = null!;

    [StringLength(250)]
    public string? Category { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("HrcustodyReportAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CustodyId")]
    [InverseProperty("HrcustodyReportAttachments")]
    public virtual Hrcustody Custody { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("HrcustodyReportAttachmentModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;
}
