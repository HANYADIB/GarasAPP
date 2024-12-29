using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOPdfTemplate")]
public partial class PurchasePopdfTemplate
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Header { get; set; } = null!;

    [StringLength(500)]
    public string Footer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column("POID")]
    public long Poid { get; set; }

    public bool Active { get; set; }

    [StringLength(500)]
    public string Signature1 { get; set; } = null!;

    [StringLength(500)]
    public string Signature2 { get; set; } = null!;

    [StringLength(500)]
    public string Body { get; set; } = null!;

    public string? LogoSrc { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchasePopdfTemplateCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("PurchasePopdfTemplateModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("Poid")]
    [InverseProperty("PurchasePopdfTemplates")]
    public virtual PurchasePo Po { get; set; } = null!;
}
