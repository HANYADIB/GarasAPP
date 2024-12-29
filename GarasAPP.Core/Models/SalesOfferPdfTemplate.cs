﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferPdfTemplate")]
public partial class SalesOfferPdfTemplate
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Header { get; set; } = null!;

    [StringLength(500)]
    public string Footer { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column("SalesOfferID")]
    public long SalesOfferId { get; set; }

    public bool Active { get; set; }

    [StringLength(500)]
    public string Signature1 { get; set; } = null!;

    [StringLength(500)]
    public string Signature2 { get; set; } = null!;

    [StringLength(500)]
    public string Body { get; set; } = null!;

    public string? LogoSrc { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesOfferPdfTemplateCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesOfferPdfTemplateModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("SalesOfferId")]
    [InverseProperty("SalesOfferPdfTemplates")]
    public virtual SalesOffer SalesOffer { get; set; } = null!;
}
