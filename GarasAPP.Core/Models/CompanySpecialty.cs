using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("CompanySpecialty")]
public partial class CompanySpecialty
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("SpecialityID")]
    public long SpecialityId { get; set; }

    [StringLength(250)]
    public string SpecialityName { get; set; } = null!;

    public string? Description { get; set; }
}
