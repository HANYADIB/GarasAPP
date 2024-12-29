using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("GF_Users")]
public partial class GfUser
{
    [Key]
    public long Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Mobile { get; set; } = null!;

    [StringLength(200)]
    public string ChurchName { get; set; } = null!;

    [StringLength(200)]
    public string Age { get; set; } = null!;

    public string Password { get; set; } = null!;
}
