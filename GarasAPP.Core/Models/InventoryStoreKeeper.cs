using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryStoreKeeper")]
public partial class InventoryStoreKeeper
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("InventoryStoreID")]
    public int InventoryStoreId { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryStoreKeeperCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("InventoryStoreId")]
    [InverseProperty("InventoryStoreKeepers")]
    public virtual InventoryStore InventoryStore { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("InventoryStoreKeeperModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("InventoryStoreKeeperUsers")]
    public virtual User User { get; set; } = null!;
}
