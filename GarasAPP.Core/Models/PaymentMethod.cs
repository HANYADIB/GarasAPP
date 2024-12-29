using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("PaymentMethod")]
public partial class PaymentMethod
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("PaymentMethod")]
    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
