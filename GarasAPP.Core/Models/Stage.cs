using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class Stage
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("StageCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Stage")]
    public virtual ICollection<ManageStage> ManageStages { get; set; } = new List<ManageStage>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("StageModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [InverseProperty("Stage")]
    public virtual ICollection<TaskStageHistory> TaskStageHistories { get; set; } = new List<TaskStageHistory>();
}
