using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceDeductionType")]
public partial class PurchasePoinvoiceDeductionType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("PodeductionType")]
    public virtual ICollection<PurchasePoinvoiceDeduction> PurchasePoinvoiceDeductions { get; set; } = new List<PurchasePoinvoiceDeduction>();
}
