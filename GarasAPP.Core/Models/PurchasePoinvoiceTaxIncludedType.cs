using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceTaxIncludedType")]
public partial class PurchasePoinvoiceTaxIncludedType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("PotaxIncludedType")]
    public virtual ICollection<PurchasePoinvoiceTaxIncluded> PurchasePoinvoiceTaxIncludeds { get; set; } = new List<PurchasePoinvoiceTaxIncluded>();
}
