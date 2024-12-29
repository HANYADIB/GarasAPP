using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PurchasePOInvoiceExtraFeesType")]
public partial class PurchasePoinvoiceExtraFeesType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("PoinvoiceExtraFeesType")]
    public virtual ICollection<PurchasePoinvoiceExtraFee> PurchasePoinvoiceExtraFees { get; set; } = new List<PurchasePoinvoiceExtraFee>();
}
