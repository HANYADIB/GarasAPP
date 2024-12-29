﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ManagementOfMaintenanceOrder")]
public partial class ManagementOfMaintenanceOrder
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("MaintenanceOfferID")]
    public long MaintenanceOfferId { get; set; }

    [Column("ProjectID")]
    public long ProjectId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public int NumberOfVisits { get; set; }

    public bool Active { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? ContractPrice { get; set; }

    [Column("CurrencyID")]
    public int? CurrencyId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? RateToLocalCu { get; set; }

    public string? ContractAttachment { get; set; }

    public string? WarrentyCertificateAttachment { get; set; }

    public string? ContractStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModificationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column("MaintenanceForID")]
    public long? MaintenanceForId { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ManagementOfMaintenanceOrderCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("ManagementOfMaintenanceOrders")]
    public virtual Currency? Currency { get; set; }

    [ForeignKey("MaintenanceForId")]
    [InverseProperty("ManagementOfMaintenanceOrders")]
    public virtual MaintenanceFor? MaintenanceFor { get; set; }

    [ForeignKey("MaintenanceOfferId")]
    [InverseProperty("ManagementOfMaintenanceOrders")]
    public virtual SalesOffer MaintenanceOffer { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ManagementOfMaintenanceOrderModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ManagementOfMaintenanceOrders")]
    public virtual Project Project { get; set; } = null!;

    [InverseProperty("ManagementOfMaintenanceOrder")]
    public virtual ICollection<VisitsScheduleOfMaintenance> VisitsScheduleOfMaintenances { get; set; } = new List<VisitsScheduleOfMaintenance>();
}