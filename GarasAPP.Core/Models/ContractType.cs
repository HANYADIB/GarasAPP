using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ContractType")]
public partial class ContractType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [InverseProperty("ContactType")]
    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
}
