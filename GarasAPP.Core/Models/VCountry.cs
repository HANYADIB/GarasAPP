using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VCountry
{
    [Column("CountryID")]
    public int CountryId { get; set; }

    [StringLength(500)]
    public string CountryName { get; set; } = null!;

    [Column("GovernorateID")]
    public int GovernorateId { get; set; }

    [StringLength(500)]
    public string GovernorateName { get; set; } = null!;

    [Column("AreaID")]
    public long AreaId { get; set; }

    [StringLength(1000)]
    public string AreaName { get; set; } = null!;
}
