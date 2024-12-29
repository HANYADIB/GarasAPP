using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOPdf")]
public partial class PurchasePopdf
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("POID")]
    public long Poid { get; set; }

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

    [StringLength(50)]
    public string FileExtension { get; set; } = null!;

    [StringLength(50)]
    public string VersionNumber { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchasePopdfCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("PurchasePopdfModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("Poid")]
    [InverseProperty("PurchasePopdfs")]
    public virtual PurchasePo Po { get; set; } = null!;
}
