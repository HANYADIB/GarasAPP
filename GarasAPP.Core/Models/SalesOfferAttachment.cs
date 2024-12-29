using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferAttachment")]
public partial class SalesOfferAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("OfferID")]
    public long OfferId { get; set; }

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

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesOfferAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesOfferAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("OfferId")]
    [InverseProperty("SalesOfferAttachments")]
    public virtual SalesOffer Offer { get; set; } = null!;

    [InverseProperty("OfferAttachment")]
    public virtual ICollection<SalesOfferAttachmentGroupPermission> SalesOfferAttachmentGroupPermissions { get; set; } = new List<SalesOfferAttachmentGroupPermission>();

    [InverseProperty("OfferAttachment")]
    public virtual ICollection<SalesOfferAttachmentUserPermission> SalesOfferAttachmentUserPermissions { get; set; } = new List<SalesOfferAttachmentUserPermission>();
}
