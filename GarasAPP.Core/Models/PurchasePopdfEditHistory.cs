using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOPdfEditHistory")]
public partial class PurchasePopdfEditHistory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("POID")]
    public long Poid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EditDate { get; set; }

    public bool Active { get; set; }

    public long EditedBy { get; set; }

    [ForeignKey("EditedBy")]
    [InverseProperty("PurchasePopdfEditHistories")]
    public virtual User EditedByNavigation { get; set; } = null!;

    [ForeignKey("Poid")]
    [InverseProperty("PurchasePopdfEditHistories")]
    public virtual PurchasePo Po { get; set; } = null!;
}
