using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Holiday")]
public partial class Holiday
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Descreption { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(250)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(250)]
    public string ModifiedBy { get; set; } = null!;

    [InverseProperty("Holiday")]
    public virtual ICollection<OffDay> OffDays { get; set; } = new List<OffDay>();
}
