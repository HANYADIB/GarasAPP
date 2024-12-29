using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VProjectInstallationTotalHour
{
    [Column("ProjectInsID")]
    public long ProjectInsId { get; set; }

    [Column(TypeName = "decimal(38, 2)")]
    public decimal? TotalHours { get; set; }
}
