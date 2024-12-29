using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalaryTax")]
public partial class SalaryTax
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Percentage { get; set; }

    public long Min { get; set; }

    public long Max { get; set; }
}
