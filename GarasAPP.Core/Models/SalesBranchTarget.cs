using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesBranchTarget")]
public partial class SalesBranchTarget
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("TargetID")]
    public int TargetId { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    public double Percentage { get; set; }

    [Column(TypeName = "decimal(18, 3)")]
    public decimal Amount { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("SalesBranchTargets")]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesBranchTargetCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("SalesBranchTargets")]
    public virtual Currency Currency { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesBranchTargetModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("TargetId")]
    [InverseProperty("SalesBranchTargets")]
    public virtual SalesTarget Target { get; set; } = null!;
}
