﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesBranchProductTarget")]
public partial class SalesBranchProductTarget
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("TargetID")]
    public int TargetId { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    [Column("ProductID")]
    public long ProductId { get; set; }

    public double Percentage { get; set; }

    [Column(TypeName = "decimal(18, 3)")]
    public decimal Amount { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("SalesBranchProductTargets")]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesBranchProductTargetCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("SalesBranchProductTargets")]
    public virtual Currency Currency { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesBranchProductTargetModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("SalesBranchProductTargets")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("TargetId")]
    [InverseProperty("SalesBranchProductTargets")]
    public virtual SalesTarget Target { get; set; } = null!;
}