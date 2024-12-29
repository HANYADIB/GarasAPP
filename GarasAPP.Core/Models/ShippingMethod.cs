using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ShippingMethod")]
public partial class ShippingMethod
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("ShippingMethod")]
    public virtual ICollection<PurchasePoshipmentShippingMethodDetail> PurchasePoshipmentShippingMethodDetails { get; set; } = new List<PurchasePoshipmentShippingMethodDetail>();
}
