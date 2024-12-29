using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Governorate")]
public partial class Governorate
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Column("CountryID")]
    public int CountryId { get; set; }

    public long? CreatedBy { get; set; }

    [Column("OldID")]
    public int? OldId { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

}
