using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePaymentMethod")]
public partial class PurchasePaymentMethod
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("PurchasePaymentMethod")]
    public virtual ICollection<PurchasePoamountPaymentMethod> PurchasePoamountPaymentMethods { get; set; } = new List<PurchasePoamountPaymentMethod>();

    [InverseProperty("PurchasePaymentMethod")]
    public virtual ICollection<PurchasePoinvoiceClosedPayment> PurchasePoinvoiceClosedPayments { get; set; } = new List<PurchasePoinvoiceClosedPayment>();
}
