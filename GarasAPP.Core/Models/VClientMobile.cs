using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VClientMobile
{
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public bool? HasLogo { get; set; }

    [Column("SalesPersonID")]
    public long SalesPersonId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(20)]
    public string? Mobile { get; set; }

    public int? NeedApproval { get; set; }

    public long? ClientSerialCounter { get; set; }
}
