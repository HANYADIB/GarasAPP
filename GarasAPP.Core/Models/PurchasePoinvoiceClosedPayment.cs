using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceClosedPayment")]
public partial class PurchasePoinvoiceClosedPayment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("POInvoiceID")]
    public long PoinvoiceId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Amount { get; set; }

    [Column("CurrencyID")]
    public int? CurrencyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [Column("PurchasePaymentMethodID")]
    public long? PurchasePaymentMethodId { get; set; }

    [Column("PurchasePOInvoiceAttachmentID")]
    public long? PurchasePoinvoiceAttachmentId { get; set; }

    [StringLength(100)]
    public string? ReceivedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReceivedIn { get; set; }

    [StringLength(50)]
    public string PaymentName { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("PurchasePoinvoiceClosedPayments")]
    public virtual Currency? Currency { get; set; }

    [ForeignKey("PoinvoiceId")]
    [InverseProperty("PurchasePoinvoiceClosedPayments")]
    public virtual PurchasePoinvoice Poinvoice { get; set; } = null!;

    [ForeignKey("PurchasePaymentMethodId")]
    [InverseProperty("PurchasePoinvoiceClosedPayments")]
    public virtual PurchasePaymentMethod? PurchasePaymentMethod { get; set; }

    [ForeignKey("PurchasePoinvoiceAttachmentId")]
    [InverseProperty("PurchasePoinvoiceClosedPayments")]
    public virtual PurchasePoinvoiceAttachment? PurchasePoinvoiceAttachment { get; set; }
}
