using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PricingClearfication")]
public partial class PricingClearfication
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("PricingID")]
    public long PricingId { get; set; }

    public long CrreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(500)]
    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public long SentTo { get; set; }

    public string? Reply { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReplyDate { get; set; }

    [ForeignKey("CrreatedBy")]
    [InverseProperty("PricingClearficationCrreatedByNavigations")]
    public virtual User CrreatedByNavigation { get; set; } = null!;

    [ForeignKey("PricingId")]
    [InverseProperty("PricingClearfications")]
    public virtual Pricing Pricing { get; set; } = null!;

    [InverseProperty("PricingClarification")]
    public virtual ICollection<PricingClarificationAttachment> PricingClarificationAttachments { get; set; } = new List<PricingClarificationAttachment>();

    [ForeignKey("SentTo")]
    [InverseProperty("PricingClearficationSentToNavigations")]
    public virtual User SentToNavigation { get; set; } = null!;
}
