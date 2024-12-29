using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InvoiceCNAndDN")]
public partial class InvoiceCnandDn
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("SalesOfferID")]
    public long SalesOfferId { get; set; }

    [Column("ParentSalesOfferID")]
    public long ParentSalesOfferId { get; set; }

    [Column("ParentInvoiceID")]
    public long ParentInvoiceId { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModificationDate { get; set; }

    public long ModifiedBy { get; set; }

    [ForeignKey("ParentInvoiceId")]
    [InverseProperty("InvoiceCnandDns")]
    public virtual Invoice ParentInvoice { get; set; } = null!;

    [ForeignKey("ParentSalesOfferId")]
    [InverseProperty("InvoiceCnandDnParentSalesOffers")]
    public virtual SalesOffer ParentSalesOffer { get; set; } = null!;

    [ForeignKey("SalesOfferId")]
    [InverseProperty("InvoiceCnandDnSalesOffers")]
    public virtual SalesOffer SalesOffer { get; set; } = null!;
}
