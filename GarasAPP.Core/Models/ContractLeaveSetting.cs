using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ContractLeaveSetting")]
public partial class ContractLeaveSetting
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string HolidayName { get; set; } = null!;

    [StringLength(250)]
    public string? AllowedPerYear { get; set; }

    [Column("AllowedPerYearID")]
    [StringLength(10)]
    public string? AllowedPerYearId { get; set; }

    public int? Balance { get; set; }

    public string? Notes { get; set; }

    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public long CreatedBy { get; set; }

    public long ModifiedBy { get; set; }

    [InverseProperty("AbsenceType")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("ContractLeaveSetting")]
    public virtual ICollection<ContractLeaveEmployee> ContractLeaveEmployees { get; set; } = new List<ContractLeaveEmployee>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("ContractLeaveSettingCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ContractLeaveSettingModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;
}
