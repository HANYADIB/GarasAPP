using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOType")]
public partial class PurchasePotype
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

    [InverseProperty("Potype")]
    public virtual ICollection<PurchasePo> PurchasePos { get; set; } = new List<PurchasePo>();
}
