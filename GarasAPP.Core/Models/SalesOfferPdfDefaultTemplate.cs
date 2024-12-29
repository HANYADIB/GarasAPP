﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferPdfDefaultTemplate")]
public partial class SalesOfferPdfDefaultTemplate
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

    [StringLength(500)]
    public string Signature1 { get; set; } = null!;

    [StringLength(500)]
    public string Signature2 { get; set; } = null!;

    [StringLength(500)]
    public string Body { get; set; } = null!;

    public bool Active { get; set; }

    public string? LogoSrc { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesOfferPdfDefaultTemplateCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesOfferPdfDefaultTemplateModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
