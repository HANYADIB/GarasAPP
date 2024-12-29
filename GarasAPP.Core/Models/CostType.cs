using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("CostType")]
public partial class CostType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("CostTypes")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("CostType")]
    public virtual ICollection<RequieredCost> RequieredCosts { get; set; } = new List<RequieredCost>();
}
