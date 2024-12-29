using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VClientUseer
{
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string Type { get; set; } = null!;

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(250)]
    public string? WebSite { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("SalesPersonID")]
    public long SalesPersonId { get; set; }

    public string? Note { get; set; }

    public int? Rate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FirstContractDate { get; set; }

    public byte[]? Logo { get; set; }

    [StringLength(500)]
    public string? GroupName { get; set; }

    [StringLength(500)]
    public string? BranchName { get; set; }

    [StringLength(250)]
    public string? Consultant { get; set; }

    public int FollowUpPeriod { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    public byte[]? Photo { get; set; }

    [StringLength(250)]
    public string? ConsultantType { get; set; }

    public bool? SupportedByCompany { get; set; }

    [StringLength(250)]
    public string? SupportedBy { get; set; }

    public bool? HasLogo { get; set; }

    [Column("ClientBranchID")]
    public int? ClientBranchId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastReportDate { get; set; }

    public int? NeedApproval { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ClientExpireDate { get; set; }

    public long? ClientSerialCounter { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? OpeningBalance { get; set; }

    [StringLength(50)]
    public string? OpeningBalanceType { get; set; }

    [Column(TypeName = "date")]
    public DateTime? OpeningBalanceDate { get; set; }

    public int? OpeningBalanceCurrencyId { get; set; }

    public int? DefaultDelivaryAndShippingMethodId { get; set; }

    [StringLength(200)]
    public string? OtherDelivaryAndShippingMethodName { get; set; }

    [StringLength(200)]
    public string? CommercialRecord { get; set; }

    [StringLength(200)]
    public string? TaxCard { get; set; }

    public bool? OwnerCoProfile { get; set; }

    public long? ApprovedBy { get; set; }

    public int? ClientClassificationId { get; set; }

    public string? ClassificationComment { get; set; }
}
