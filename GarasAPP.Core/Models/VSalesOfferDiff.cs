using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VSalesOfferDiff
{
    [Column("ID")]
    public long Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Column("ClientID")]
    public long? ClientId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OfferAmount { get; set; }

    [Column("diff")]
    public int? Diff { get; set; }

    [Column("SalesPersonID")]
    public long SalesPersonId { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    [StringLength(50)]
    public string? OfferType { get; set; }

    [StringLength(250)]
    public string? Status { get; set; }
}
