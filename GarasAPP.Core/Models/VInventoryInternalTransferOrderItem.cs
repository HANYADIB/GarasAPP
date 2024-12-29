using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VInventoryInternalTransferOrderItem
{
    [Column("ID")]
    public long Id { get; set; }

    [Column("InventoryInternalTransferOrderID")]
    public long InventoryInternalTransferOrderId { get; set; }

    [Column("InventoryItemID")]
    public long InventoryItemId { get; set; }

    [Column("UOMID")]
    public int Uomid { get; set; }

    [StringLength(50)]
    public string? ItemSerial { get; set; }

    public string? Comments { get; set; }

    [Column("TransferredQTY", TypeName = "decimal(18, 4)")]
    public decimal TransferredQty { get; set; }

    public string ItemName { get; set; } = null!;

    [Column("UOMShortName")]
    [StringLength(50)]
    public string? UomshortName { get; set; }

    [StringLength(50)]
    public string Code { get; set; } = null!;

    [Column("PurchasingUOMID")]
    public int PurchasingUomid { get; set; }

    [Column("RequstionUOMID")]
    public int RequstionUomid { get; set; }

    [Column("RequstionUOMShortName")]
    [StringLength(50)]
    public string? RequstionUomshortName { get; set; }

    [Column("PurchasingUOMShortName")]
    [StringLength(50)]
    public string? PurchasingUomshortName { get; set; }
}
