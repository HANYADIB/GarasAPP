using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryInternalBackOrder")]
public partial class InventoryInternalBackOrder
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string OperationType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public int Revision { get; set; }

    [Column("FromID")]
    public long FromId { get; set; }

    [Column("InventoryStoreID")]
    public int InventoryStoreId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecivingDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public bool Custody { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryInternalBackOrderCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("FromId")]
    [InverseProperty("InventoryInternalBackOrderFroms")]
    public virtual User From { get; set; } = null!;

    [InverseProperty("InventoryInternalBackOrder")]
    public virtual ICollection<InventoryInternalBackOrderItem> InventoryInternalBackOrderItems { get; set; } = new List<InventoryInternalBackOrderItem>();

    [ForeignKey("InventoryStoreId")]
    [InverseProperty("InventoryInternalBackOrders")]
    public virtual InventoryStore InventoryStore { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("InventoryInternalBackOrderModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
