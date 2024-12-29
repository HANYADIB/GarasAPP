using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("BOMPartitionItemAttachments")]
public partial class BompartitionItemAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("BOMPartitionItemID")]
    public long BompartitionItemId { get; set; }

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtenssion { get; set; } = null!;

    [StringLength(250)]
    public string? Category { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("BompartitionItemId")]
    [InverseProperty("BompartitionItemAttachments")]
    public virtual BompartitionItem BompartitionItem { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BompartitionItemAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("BompartitionItemAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
