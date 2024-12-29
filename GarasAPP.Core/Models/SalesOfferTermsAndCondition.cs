using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class SalesOfferTermsAndCondition
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("SalesOfferID")]
    public long SalesOfferId { get; set; }

    [StringLength(250)]
    public string TermsCategoryName { get; set; } = null!;

    [StringLength(250)]
    public string TermsName { get; set; } = null!;

    public string TermsDescription { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesOfferTermsAndConditionCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesOfferTermsAndConditionModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("SalesOfferId")]
    [InverseProperty("SalesOfferTermsAndConditions")]
    public virtual SalesOffer SalesOffer { get; set; } = null!;
}
