using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Task")]
public partial class Task
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExpireDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Required]
    public bool? Active { get; set; }

    [StringLength(500)]
    public string TaskUser { get; set; } = null!;

    [Column("TaskTypeID")]
    public int TaskTypeId { get; set; }

    [StringLength(100)]
    public string RefrenceNumber { get; set; } = null!;

    [StringLength(500)]
    public string? TaskCategory { get; set; }

    public string? TaskSubject { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [StringLength(250)]
    public string? TaskPage { get; set; }

    public bool GroupReply { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TaskCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TaskModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("Task")]
    public virtual ICollection<TaskDetail> TaskDetails { get; set; } = new List<TaskDetail>();

    [InverseProperty("Task")]
    public virtual ICollection<TaskFlagsOwnerReciever> TaskFlagsOwnerRecievers { get; set; } = new List<TaskFlagsOwnerReciever>();

    [InverseProperty("Task")]
    public virtual ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();

    [InverseProperty("Task")]
    public virtual ICollection<TaskPermission> TaskPermissions { get; set; } = new List<TaskPermission>();

    [ForeignKey("TaskTypeId")]
    [InverseProperty("Tasks")]
    public virtual TaskType TaskType { get; set; } = null!;

    [InverseProperty("Task")]
    public virtual ICollection<TaskUserReply> TaskUserReplies { get; set; } = new List<TaskUserReply>();
}
