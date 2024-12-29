using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("AllowncesType")]
public partial class AllowncesType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;

    [InverseProperty("AllowncesType")]
    public virtual ICollection<SalaryAllownce> SalaryAllownces { get; set; } = new List<SalaryAllownce>();
}
