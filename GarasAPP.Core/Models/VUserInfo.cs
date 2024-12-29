using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VUserInfo
{
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Mobile { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string? MiddleName { get; set; }

    public int? Age { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    public long? CreatedBy { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("JobTitleID")]
    public int? JobTitleId { get; set; }

    [Column("OldID")]
    public int? OldId { get; set; }

    [StringLength(500)]
    public string? UserDepartmentName { get; set; }

    [StringLength(500)]
    public string? UserBranchName { get; set; }

    [StringLength(500)]
    public string? UserJobTitle { get; set; }
}
