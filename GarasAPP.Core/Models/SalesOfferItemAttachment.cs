using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferItemAttachment")]
public partial class SalesOfferItemAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("OfferID")]
    public long OfferId { get; set; }

    [Column("InventoryItemID")]
    public long InventoryItemId { get; set; }

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

    [StringLength(250)]
    public string? Category { get; set; }

    public long? SalesOfferProductId { get; set; }

    [ForeignKey("InventoryItemId")]
    [InverseProperty("SalesOfferItemAttachments")]
    public virtual InventoryItem InventoryItem { get; set; } = null!;

    [ForeignKey("OfferId")]
    [InverseProperty("SalesOfferItemAttachments")]
    public virtual SalesOffer Offer { get; set; } = null!;

    [ForeignKey("SalesOfferProductId")]
    [InverseProperty("SalesOfferItemAttachments")]
    public virtual SalesOfferProduct? SalesOfferProduct { get; set; }
}
