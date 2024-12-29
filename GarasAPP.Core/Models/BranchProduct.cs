﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("BranchProduct")]
public partial class BranchProduct
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    [Column("ProductID")]
    public long ProductId { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("BranchProducts")]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("BranchProducts")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("BranchProducts")]
    public virtual Product Product { get; set; } = null!;
}
