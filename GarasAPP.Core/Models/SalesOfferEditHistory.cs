using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferEditHistory")]
public partial class SalesOfferEditHistory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("SalesOfferID")]
    public long SalesOfferId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EditDate { get; set; }

    public bool Active { get; set; }

    public long EditedBy { get; set; }

    [ForeignKey("EditedBy")]
    [InverseProperty("SalesOfferEditHistories")]
    public virtual User EditedByNavigation { get; set; } = null!;

    [ForeignKey("SalesOfferId")]
    [InverseProperty("SalesOfferEditHistories")]
    public virtual SalesOffer SalesOffer { get; set; } = null!;
}
