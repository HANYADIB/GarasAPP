using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchaseRequest")]
public partial class PurchaseRequest
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ToUserID")]
    public long? ToUserId { get; set; }

    [Column("FromInventoryStoreID")]
    public int FromInventoryStoreId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public bool Active { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("MatrialRequestID")]
    public long MatrialRequestId { get; set; }

    [Column("IsDirectPR")]
    public bool? IsDirectPr { get; set; }

    [StringLength(50)]
    public string? ApprovalStatus { get; set; }

    [Column("ApprovalUserID")]
    public long? ApprovalUserId { get; set; }

    [StringLength(500)]
    public string? ApprovalReplyNotes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ApprovalReplyData { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchaseRequestCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("FromInventoryStoreId")]
    [InverseProperty("PurchaseRequests")]
    public virtual InventoryStore FromInventoryStore { get; set; } = null!;

    [ForeignKey("MatrialRequestId")]
    [InverseProperty("PurchaseRequests")]
    public virtual InventoryMatrialRequest MatrialRequest { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("PurchaseRequestModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("Pr")]
    public virtual ICollection<PrsupplierOffer> PrsupplierOffers { get; set; } = new List<PrsupplierOffer>();

    [InverseProperty("PurchaseRequest")]
    public virtual ICollection<PurchaseRequestItem> PurchaseRequestItems { get; set; } = new List<PurchaseRequestItem>();

    [ForeignKey("ToUserId")]
    [InverseProperty("PurchaseRequestToUsers")]
    public virtual User? ToUser { get; set; }
}
