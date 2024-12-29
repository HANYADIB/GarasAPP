using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskCategory")]
public partial class TaskCategory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    [InverseProperty("TaskCategory")]
    public virtual ICollection<TaskInfoRevision> TaskInfoRevisions { get; set; } = new List<TaskInfoRevision>();

    [InverseProperty("TaskCategory")]
    public virtual ICollection<TaskInfo> TaskInfos { get; set; } = new List<TaskInfo>();

    [InverseProperty("TaskCategory")]
    public virtual ICollection<TaskPrimarySubCategory> TaskPrimarySubCategories { get; set; } = new List<TaskPrimarySubCategory>();
}
