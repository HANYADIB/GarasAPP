using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryMaterialRequestType")]
public partial class InventoryMaterialRequestType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(200)]
    public string TypeName { get; set; } = null!;

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModificationDate { get; set; }

    [InverseProperty("RequestType")]
    public virtual ICollection<InventoryMatrialRequest> InventoryMatrialRequests { get; set; } = new List<InventoryMatrialRequest>();
}
