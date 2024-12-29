using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PricingTerm")]
public partial class PricingTerm
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column("TermGroupID")]
    public int TermGroupId { get; set; }

    [Column("PricingID")]
    public long PricingId { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PricingTermCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("PricingTermModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("PricingId")]
    [InverseProperty("PricingTerms")]
    public virtual Pricing Pricing { get; set; } = null!;

    [ForeignKey("TermGroupId")]
    [InverseProperty("PricingTerms")]
    public virtual TermsGroup TermGroup { get; set; } = null!;
}
