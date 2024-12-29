using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VPricingFullDatum
{
    [Column("PricingID")]
    public long PricingId { get; set; }

    [StringLength(100)]
    public string Status { get; set; } = null!;

    public bool Active { get; set; }

    public bool SalesHeadApprove { get; set; }

    public bool PricingHeadApprove { get; set; }

    [Column("PricingPersonID")]
    public long? PricingPersonId { get; set; }

    [StringLength(250)]
    public string PricingType { get; set; } = null!;

    public bool Completed { get; set; }

    [Column("RefID")]
    public long? RefId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Column("SalesPersonID")]
    public long? SalesPersonId { get; set; }

    public bool? SalesActive { get; set; }

    public int? VersionNumber { get; set; }

    [StringLength(500)]
    public string? ProductType { get; set; }

    [StringLength(500)]
    public string? ProjectName { get; set; }

    [Column("ClientID")]
    public long? ClientId { get; set; }

    [StringLength(500)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    public bool? UserActive { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    public byte[]? Photo { get; set; }

    [Column("PricingBranshID")]
    public int PricingBranshId { get; set; }
}
