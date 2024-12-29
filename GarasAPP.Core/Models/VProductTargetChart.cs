using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VProductTargetChart
{
    [Column("BranchID")]
    public int BranchId { get; set; }

    [StringLength(500)]
    public string BranchName { get; set; } = null!;

    [Column("ProductID")]
    public long ProductId { get; set; }

    [StringLength(1000)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "decimal(18, 3)")]
    public decimal Amount { get; set; }

    public int Year { get; set; }
}
