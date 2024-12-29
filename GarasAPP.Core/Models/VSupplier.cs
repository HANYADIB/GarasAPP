using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VSupplier
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

    public string? Note { get; set; }

    public int? Rate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? FirstContractDate { get; set; }

    public byte[]? Logo { get; set; }

    public bool? HasLogo { get; set; }

    public bool Active { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("CountryID")]
    public int? CountryId { get; set; }

    [Column("GovernorateID")]
    public int? GovernorateId { get; set; }

    public string? Address { get; set; }

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

    public long? SupplierSerialCounter { get; set; }

    [StringLength(200)]
    public string? RegistrationNumber { get; set; }
}
