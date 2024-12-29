using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VPoapprovalStatus
{
    [Column("ID")]
    public long Id { get; set; }

    public bool Mandatory { get; set; }

    [StringLength(400)]
    public string Name { get; set; } = null!;

    [Column("POID")]
    public long Poid { get; set; }

    [Column("POApprovalSettingID")]
    public int PoapprovalSettingId { get; set; }

    [Column("ApprovalUserID")]
    public long ApprovalUserId { get; set; }

    public bool IsApproved { get; set; }

    public string? Comment { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;
}
