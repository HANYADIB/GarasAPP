using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceAttachment")]
public partial class PurchasePoinvoiceAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtenssion { get; set; } = null!;

    [StringLength(50)]
    public string Category { get; set; } = null!;

    [Column("PurchasePOInvoiceID")]
    public long PurchasePoinvoiceId { get; set; }

    [ForeignKey("PurchasePoinvoiceId")]
    [InverseProperty("PurchasePoinvoiceAttachments")]
    public virtual PurchasePoinvoice PurchasePoinvoice { get; set; } = null!;

    [InverseProperty("PurchasePoinvoiceAttachment")]
    public virtual ICollection<PurchasePoinvoiceClosedPayment> PurchasePoinvoiceClosedPayments { get; set; } = new List<PurchasePoinvoiceClosedPayment>();

    [InverseProperty("InvoiceAttachement")]
    public virtual ICollection<PurchasePoinvoice> PurchasePoinvoices { get; set; } = new List<PurchasePoinvoice>();
}
