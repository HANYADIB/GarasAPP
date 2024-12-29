using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VUserBranchGroup
{
    [Column("UserID")]
    public long UserId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(500)]
    public string GroupName { get; set; } = null!;
}
