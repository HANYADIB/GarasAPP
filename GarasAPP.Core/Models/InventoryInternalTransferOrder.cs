using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryInternalTransferOrder")]
public partial class InventoryInternalTransferOrder
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string OperationType { get; set; } = null!;

    public int Revision { get; set; }

    [Column("FromInventoryStoreID")]
    public int FromInventoryStoreId { get; set; }

    [Column("ToInventoryStoreID")]
    public int ToInventoryStoreId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecivingDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryInternalTransferOrderCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("FromInventoryStoreId")]
    [InverseProperty("InventoryInternalTransferOrderFromInventoryStores")]
    public virtual InventoryStore FromInventoryStore { get; set; } = null!;

    [InverseProperty("InventoryInternalTransferOrder")]
    public virtual ICollection<InventoryInternalTransferOrderItem> InventoryInternalTransferOrderItems { get; set; } = new List<InventoryInternalTransferOrderItem>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("InventoryInternalTransferOrderModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ToInventoryStoreId")]
    [InverseProperty("InventoryInternalTransferOrderToInventoryStores")]
    public virtual InventoryStore ToInventoryStore { get; set; } = null!;
}
