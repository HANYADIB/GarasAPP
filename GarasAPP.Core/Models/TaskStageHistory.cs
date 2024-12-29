using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskStageHistory")]
public partial class TaskStageHistory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("StageID")]
    public long StageId { get; set; }

    [Column("TaskInfoID")]
    public long TaskInfoId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TaskStageHistoryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TaskStageHistoryModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("StageId")]
    [InverseProperty("TaskStageHistories")]
    public virtual Stage Stage { get; set; } = null!;

    [ForeignKey("TaskInfoId")]
    [InverseProperty("TaskStageHistories")]
    public virtual TaskInfo TaskInfo { get; set; } = null!;
}
