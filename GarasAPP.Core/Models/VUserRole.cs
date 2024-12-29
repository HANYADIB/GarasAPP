using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VUserRole
{
    [Column("ID")]
    public long Id { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(250)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Mobile { get; set; }

    public bool? Active { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("JobTitleID")]
    public int? JobTitleId { get; set; }

    [StringLength(500)]
    public string RoleName { get; set; } = null!;
}
