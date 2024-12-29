using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VInventoryItemInventoryItemCategory
{
    [Column("ID")]
    public long Id { get; set; }

    public string ItemName { get; set; } = null!;

    public bool ItemActive { get; set; }

    [Column("InventoryItemCategoryID")]
    public int InventoryItemCategoryId { get; set; }

    [StringLength(1000)]
    public string? CategoryName { get; set; }

    public bool? IsFinalProduct { get; set; }

    public bool? IsRentItem { get; set; }

    public bool? IsAsset { get; set; }

    public bool? IsNonStock { get; set; }

    public bool? CategoryActive { get; set; }
}
