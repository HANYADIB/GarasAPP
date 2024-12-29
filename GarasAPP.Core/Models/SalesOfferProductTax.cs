using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferProductTax")]
public partial class SalesOfferProductTax
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("Tax_ID")]
    public long TaxId { get; set; }

    [Column("SalesOfferProductID")]
    public long SalesOfferProductId { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal Percentage { get; set; }

    [Column(TypeName = "decimal(18, 5)")]
    public decimal? Value { get; set; }

    [ForeignKey("SalesOfferProductId")]
    [InverseProperty("SalesOfferProductTaxes")]
    public virtual SalesOfferProduct SalesOfferProduct { get; set; } = null!;

    [ForeignKey("TaxId")]
    [InverseProperty("SalesOfferProductTaxes")]
    public virtual Tax Tax { get; set; } = null!;
}
