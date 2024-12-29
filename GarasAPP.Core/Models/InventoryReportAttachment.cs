using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryReportAttachment")]
public partial class InventoryReportAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("InventoryReportID")]
    public long InventoryReportId { get; set; }

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
    public string Type { get; set; } = null!;

    [ForeignKey("InventoryReportId")]
    [InverseProperty("InventoryReportAttachments")]
    public virtual InventoryReport InventoryReport { get; set; } = null!;
}
