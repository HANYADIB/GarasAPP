using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceNotIncludedTaxType")]
public partial class PurchasePoinvoiceNotIncludedTaxType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("PonotIncludedTaxType")]
    public virtual ICollection<PurchasePoinvoiceNotIncludedTax> PurchasePoinvoiceNotIncludedTaxes { get; set; } = new List<PurchasePoinvoiceNotIncludedTax>();
}
