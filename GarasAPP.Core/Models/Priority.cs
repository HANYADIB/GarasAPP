using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Priority")]
public partial class Priority
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [InverseProperty("Priority")]
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    [InverseProperty("Priority")]
    public virtual ICollection<ProjectTmrevision> ProjectTmrevisions { get; set; } = new List<ProjectTmrevision>();

    [InverseProperty("Priorty")]
    public virtual ICollection<ProjectTm> ProjectTms { get; set; } = new List<ProjectTm>();

    [InverseProperty("Proiority")]
    public virtual ICollection<TaskInfoRevision> TaskInfoRevisions { get; set; } = new List<TaskInfoRevision>();
}
