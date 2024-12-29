using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("BOMPartitionAttachments")]
public partial class BompartitionAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("BOMPartitionID")]
    public long BompartitionId { get; set; }

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

    [ForeignKey("BompartitionId")]
    [InverseProperty("BompartitionAttachments")]
    public virtual Bompartition Bompartition { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BompartitionAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("BompartitionAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
