using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VUserDetail
{
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string? MiddleName { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(152)]
    public string UserFullName { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [Column("RoleID")]
    public int? RoleId { get; set; }

    [StringLength(500)]
    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(500)]
    public string? BranchName { get; set; }

    public string? BranchDescription { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [StringLength(500)]
    public string? DepartmentName { get; set; }

    public string? DepartmentDescription { get; set; }

    [Column("JobTitleID")]
    public int? JobTitleId { get; set; }

    [StringLength(500)]
    public string? JobTitleName { get; set; }

    public string? JobTitleDescription { get; set; }
}
