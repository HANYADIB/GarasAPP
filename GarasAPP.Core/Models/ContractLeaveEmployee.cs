using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ContractLeaveEmployee")]
public partial class ContractLeaveEmployee
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("ContractID")]
    public long ContractId { get; set; }

    [Column("ContractLeaveSettingID")]
    public int ContractLeaveSettingId { get; set; }

    public bool Active { get; set; }

    [StringLength(250)]
    public string LeaveAllowed { get; set; } = null!;

    public int? Balance { get; set; }

    public int? Used { get; set; }

    public int? Remain { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public long ModifiedBy { get; set; }

    [ForeignKey("ContractId")]
    [InverseProperty("ContractLeaveEmployees")]
    public virtual ContractDetail Contract { get; set; } = null!;

    [ForeignKey("ContractLeaveSettingId")]
    [InverseProperty("ContractLeaveEmployees")]
    public virtual ContractLeaveSetting ContractLeaveSetting { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ContractLeaveEmployeeCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ContractLeaveEmployeeModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ContractLeaveEmployeeUsers")]
    public virtual User User { get; set; } = null!;
}
