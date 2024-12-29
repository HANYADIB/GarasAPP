using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class TaskDetail
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("TaskID")]
    public long TaskId { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [StringLength(10)]
    public string Priority { get; set; } = null!;

    public bool? NeedApproval { get; set; }

    public string? CreatorAttachement { get; set; }

    [ForeignKey("TaskId")]
    [InverseProperty("TaskDetails")]
    public virtual Task Task { get; set; } = null!;
}
