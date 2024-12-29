using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class ManageStage
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectTMID")]
    public long ProjectTmid { get; set; }

    [Column("StageID")]
    public long StageId { get; set; }

    public long CreateBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreateBy")]
    [InverseProperty("ManageStageCreateByNavigations")]
    public virtual User CreateByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ManageStageModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("ProjectTmid")]
    [InverseProperty("ManageStages")]
    public virtual ProjectTm ProjectTm { get; set; } = null!;

    [ForeignKey("StageId")]
    [InverseProperty("ManageStages")]
    public virtual Stage Stage { get; set; } = null!;

    [InverseProperty("ManageStage")]
    public virtual ICollection<TaskInfo> TaskInfos { get; set; } = new List<TaskInfo>();
}
