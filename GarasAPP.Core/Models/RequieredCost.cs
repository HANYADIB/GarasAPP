using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("RequieredCost")]
public partial class RequieredCost
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("MovementAndDeliveryOrderID")]
    public long MovementAndDeliveryOrderId { get; set; }

    [Column("CostTypeID")]
    public long CostTypeId { get; set; }

    [StringLength(500)]
    public string? Comment { get; set; }

    [StringLength(500)]
    public string? ConfirmComment { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Amount { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? ConfirmAmount { get; set; }

    public bool FinalStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long CreatedBy { get; set; }

    [ForeignKey("CostTypeId")]
    [InverseProperty("RequieredCosts")]
    public virtual CostType CostType { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("RequieredCostCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("RequieredCostModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("MovementAndDeliveryOrderId")]
    [InverseProperty("RequieredCosts")]
    public virtual MovementsAndDeliveryOrder MovementAndDeliveryOrder { get; set; } = null!;

    [InverseProperty("RequieredCost")]
    public virtual ICollection<RequieredCostAttachment> RequieredCostAttachments { get; set; } = new List<RequieredCostAttachment>();
}
