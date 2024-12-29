using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VBranchUser
{
    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Mobile { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string? MiddleName { get; set; }

    public int? Age { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("JobTitleID")]
    public int? JobTitleId { get; set; }

    [StringLength(500)]
    public string? BranchName { get; set; }
}
