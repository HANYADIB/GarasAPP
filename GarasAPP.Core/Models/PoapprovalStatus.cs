using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("POApprovalStatus")]
public partial class PoapprovalStatus
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("POID")]
    public long Poid { get; set; }

    [Column("POApprovalSettingID")]
    public int PoapprovalSettingId { get; set; }

    [Column("ApprovalUserID")]
    public long ApprovalUserId { get; set; }

    public bool IsApproved { get; set; }

    public string? Comment { get; set; }

    [StringLength(250)]
    public string CreationBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [ForeignKey("ApprovalUserId")]
    [InverseProperty("PoapprovalStatuses")]
    public virtual User ApprovalUser { get; set; } = null!;

    [ForeignKey("Poid")]
    [InverseProperty("PoapprovalStatuses")]
    public virtual PurchasePo Po { get; set; } = null!;

    [ForeignKey("PoapprovalSettingId")]
    [InverseProperty("PoapprovalStatuses")]
    public virtual PoapprovalSetting PoapprovalSetting { get; set; } = null!;
}
