﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GarasAPP.Core.Models.HotelModels;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Client")]
public partial class Client
{
    [Key]
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

    public long? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    [Column("SalesPersonID")]
    public long? SalesPersonId { get; set; }

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

    [StringLength(250)]
    public string? ConsultantType { get; set; }

    public bool? SupportedByCompany { get; set; }

    [StringLength(250)]
    public string? SupportedBy { get; set; }

    public bool? HasLogo { get; set; }

    //[Column("BranchID")]
    //public int? BranchId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastReportDate { get; set; }

    /// <summary>
    /// (0 =&gt; Approved, 1 =&gt; NeedApproval, 2 =&gt; Rejected)
    /// </summary>
    public int? NeedApproval { get; set; }

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
    [ForeignKey("Nationalities")]
    public int? NationalityId { get; set; } = null;
    public virtual Nationality Nationalities { get; set; } 

    //[ForeignKey("ApprovedBy")]
    //[InverseProperty("ClientApprovedByNavigations")]
    //public virtual User? ApprovedByNavigation { get; set; }

    //[ForeignKey("BranchId")]
    //[InverseProperty("Clients")]
    //public virtual Branch? Branch { get; set; }

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientAccount> ClientAccounts { get; set; } = new List<ClientAccount>();

    public virtual ICollection<ClientAddress> ClientAddresses { get; set; } = new List<ClientAddress>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientAttachment> ClientAttachments { get; set; } = new List<ClientAttachment>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientBankAccount> ClientBankAccounts { get; set; } = new List<ClientBankAccount>();

    //[ForeignKey("ClientClassificationId")]
    //[InverseProperty("Clients")]
    //public virtual ClientClassification? ClientClassification { get; set; }

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientContactPerson> ClientContactPeople { get; set; } = new List<ClientContactPerson>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientMobile> ClientMobiles { get; set; } = new List<ClientMobile>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientPaymentTerm> ClientPaymentTerms { get; set; } = new List<ClientPaymentTerm>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientPhone> ClientPhones { get; set; } = new List<ClientPhone>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientSalesPerson> ClientSalesPeople { get; set; } = new List<ClientSalesPerson>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientSession> ClientSessions { get; set; } = new List<ClientSession>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ClientSpeciality> ClientSpecialities { get; set; } = new List<ClientSpeciality>();

    //[ForeignKey("CreatedBy")]
    //[InverseProperty("ClientCreatedByNavigations")]
    //public virtual User CreatedByNavigation { get; set; } = null!;

    //[InverseProperty("Client")]
    //public virtual ICollection<Crmreport> Crmreports { get; set; } = new List<Crmreport>();

    //[InverseProperty("Client")]
    //public virtual ICollection<DailyReportLine> DailyReportLines { get; set; } = new List<DailyReportLine>();

    //[ForeignKey("DefaultDelivaryAndShippingMethodId")]
    //[InverseProperty("Clients")]
    //public virtual DeliveryAndShippingMethod? DefaultDelivaryAndShippingMethod { get; set; }

    //[InverseProperty("Client")]
    //public virtual ICollection<MaintenanceFor> MaintenanceFors { get; set; } = new List<MaintenanceFor>();

    //[ForeignKey("OpeningBalanceCurrencyId")]
    //[InverseProperty("Clients")]
    //public virtual Currency? OpeningBalanceCurrency { get; set; }

    //[InverseProperty("Client")]
    //public virtual ICollection<ProjectTmrevision> ProjectTmrevisions { get; set; } = new List<ProjectTmrevision>();

    //[InverseProperty("Client")]
    //public virtual ICollection<ProjectTm> ProjectTms { get; set; } = new List<ProjectTm>();

    //[InverseProperty("InvoicePayerClient")]
    //public virtual ICollection<SalesOfferDiscount> SalesOfferDiscounts { get; set; } = new List<SalesOfferDiscount>();

    //[InverseProperty("InvoicePayerClient")]
    //public virtual ICollection<SalesOfferExtraCost> SalesOfferExtraCosts { get; set; } = new List<SalesOfferExtraCost>();

    //[InverseProperty("InvoicePayerClient")]
    //public virtual ICollection<SalesOfferInvoiceTax> SalesOfferInvoiceTaxes { get; set; } = new List<SalesOfferInvoiceTax>();

    //[InverseProperty("InvoicePayerClient")]
    //public virtual ICollection<SalesOfferProduct> SalesOfferProducts { get; set; } = new List<SalesOfferProduct>();

    //[InverseProperty("Client")]
    //public virtual ICollection<SalesOffer> SalesOffers { get; set; } = new List<SalesOffer>();

    //[ForeignKey("SalesPersonId")]
    //[InverseProperty("ClientSalesPeople")]
    //public virtual User SalesPerson { get; set; } = null!;

    //[InverseProperty("Client")]
    //public virtual ICollection<VehiclePerClient> VehiclePerClients { get; set; } = new List<VehiclePerClient>();
}
