using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceType")]
public partial class PurchasePoinvoiceType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public bool IsDraft { get; set; }

    [InverseProperty("PurchasePoinvoiceType")]
    public virtual ICollection<PurchasePoinvoice> PurchasePoinvoices { get; set; } = new List<PurchasePoinvoice>();
}
