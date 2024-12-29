using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectFabricationBOQ")]
public partial class ProjectFabricationBoq
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long? SalesOfferProductId { get; set; }

    public double Quantity { get; set; }

    [Column("ProjectFabricationID")]
    public long ProjectFabricationId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(250)]
    public string? ItemSerial { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectFabricationBoqCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("FabricationOrderItem")]
    public virtual ICollection<InventoryMatrialRequestItem> InventoryMatrialRequestItems { get; set; } = new List<InventoryMatrialRequestItem>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectFabricationBoqModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProjectFabricationId")]
    [InverseProperty("ProjectFabricationBoqs")]
    public virtual ProjectFabrication ProjectFabrication { get; set; } = null!;

    [ForeignKey("SalesOfferProductId")]
    [InverseProperty("ProjectFabricationBoqs")]
    public virtual SalesOfferProduct? SalesOfferProduct { get; set; }
}
