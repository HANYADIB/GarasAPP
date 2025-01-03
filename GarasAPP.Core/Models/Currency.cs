﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Currency")]
public partial class Currency
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(5)]
    public string ShortName { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(250)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(250)]
    public string? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool? IsLocal { get; set; }

    [InverseProperty("Currency")]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    [InverseProperty("Currency")]
    public virtual ICollection<Bomlibrary> Bomlibraries { get; set; } = new List<Bomlibrary>();

    [InverseProperty("OpeningBalanceCurrency")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("FromCurrency")]
    public virtual ICollection<ExchangeRate> ExchangeRateFromCurrencies { get; set; } = new List<ExchangeRate>();

    [InverseProperty("ToCurrency")]
    public virtual ICollection<ExchangeRate> ExchangeRateToCurrencies { get; set; } = new List<ExchangeRate>();

    [InverseProperty("DefaultCurrency")]
    public virtual ICollection<ExtraCostLibrary> ExtraCostLibraries { get; set; } = new List<ExtraCostLibrary>();

    [InverseProperty("Currency")]
    public virtual ICollection<ManagementOfMaintenanceOrder> ManagementOfMaintenanceOrders { get; set; } = new List<ManagementOfMaintenanceOrder>();

    [InverseProperty("Currency")]
    public virtual ICollection<PricingBom> PricingBoms { get; set; } = new List<PricingBom>();

    [InverseProperty("Currency")]
    public virtual ICollection<PricingExtraCost> PricingExtraCostCurrencies { get; set; } = new List<PricingExtraCost>();

    [InverseProperty("LocalCurrency")]
    public virtual ICollection<PricingExtraCost> PricingExtraCostLocalCurrencies { get; set; } = new List<PricingExtraCost>();

    [InverseProperty("Currency")]
    public virtual ICollection<PrsupplierOfferItem> PrsupplierOfferItems { get; set; } = new List<PrsupplierOfferItem>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceCalculatedShipmentValue> PurchasePoinvoiceCalculatedShipmentValues { get; set; } = new List<PurchasePoinvoiceCalculatedShipmentValue>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceClosedPayment> PurchasePoinvoiceClosedPayments { get; set; } = new List<PurchasePoinvoiceClosedPayment>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceDeduction> PurchasePoinvoiceDeductions { get; set; } = new List<PurchasePoinvoiceDeduction>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceExtraFee> PurchasePoinvoiceExtraFees { get; set; } = new List<PurchasePoinvoiceExtraFee>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceFinalExpensi> PurchasePoinvoiceFinalExpensis { get; set; } = new List<PurchasePoinvoiceFinalExpensi>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceNotIncludedTax> PurchasePoinvoiceNotIncludedTaxes { get; set; } = new List<PurchasePoinvoiceNotIncludedTax>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceTaxIncluded> PurchasePoinvoiceTaxIncludeds { get; set; } = new List<PurchasePoinvoiceTaxIncluded>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoinvoiceTotalOrderCustomFee> PurchasePoinvoiceTotalOrderCustomFees { get; set; } = new List<PurchasePoinvoiceTotalOrderCustomFee>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoitem> PurchasePoitems { get; set; } = new List<PurchasePoitem>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoshipmentDocument> PurchasePoshipmentDocuments { get; set; } = new List<PurchasePoshipmentDocument>();

    [InverseProperty("Currency")]
    public virtual ICollection<PurchasePoshipmentShippingMethodDetail> PurchasePoshipmentShippingMethodDetails { get; set; } = new List<PurchasePoshipmentShippingMethodDetail>();

    [InverseProperty("Currency")]
    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    [InverseProperty("Currency")]
    public virtual ICollection<SalesBranchProductTarget> SalesBranchProductTargets { get; set; } = new List<SalesBranchProductTarget>();

    [InverseProperty("Currency")]
    public virtual ICollection<SalesBranchTarget> SalesBranchTargets { get; set; } = new List<SalesBranchTarget>();

    [InverseProperty("Currency")]
    public virtual ICollection<SalesBranchUserProductTarget> SalesBranchUserProductTargets { get; set; } = new List<SalesBranchUserProductTarget>();

    [InverseProperty("Currency")]
    public virtual ICollection<SalesBranchUserTarget> SalesBranchUserTargets { get; set; } = new List<SalesBranchUserTarget>();
}
