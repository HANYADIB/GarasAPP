using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VInventoryStoreItemMinBalance
{
    [Column("InventoryItemID")]
    public long InventoryItemId { get; set; }

    public bool? Active { get; set; }

    public double? Balance { get; set; }

    public double? MinBalance { get; set; }

    public bool? StoreActive { get; set; }

    [Column("InventoryStoreID")]
    public int InventoryStoreId { get; set; }

    public string? InventoryItemName { get; set; }

    [StringLength(50)]
    public string? Code { get; set; }
}
