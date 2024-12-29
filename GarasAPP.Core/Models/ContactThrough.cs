using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ContactThrough")]
public partial class ContactThrough
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    [StringLength(250)]
    public string CreationBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [InverseProperty("ContactThrough")]
    public virtual ICollection<PofinalSelecteSupplier> PofinalSelecteSuppliers { get; set; } = new List<PofinalSelecteSupplier>();
}
