using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryMatrialRelease")]
public partial class InventoryMatrialRelease
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ToUserID")]
    public long ToUserId { get; set; }

    [Column("FromInventoryStoreID")]
    public int FromInventoryStoreId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public bool Active { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("MatrialRequestID")]
    public long MatrialRequestId { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryMatrialReleaseCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("FromInventoryStoreId")]
    [InverseProperty("InventoryMatrialReleases")]
    public virtual InventoryStore FromInventoryStore { get; set; } = null!;

    [InverseProperty("InventoryMatrialReleaset")]
    public virtual ICollection<InventoryMatrialReleaseItem> InventoryMatrialReleaseItems { get; set; } = new List<InventoryMatrialReleaseItem>();

    [ForeignKey("MatrialRequestId")]
    [InverseProperty("InventoryMatrialReleases")]
    public virtual InventoryMatrialRequest MatrialRequest { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("InventoryMatrialReleaseModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ToUserId")]
    [InverseProperty("InventoryMatrialReleaseToUsers")]
    public virtual User ToUser { get; set; } = null!;
}
