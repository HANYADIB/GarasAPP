using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskAssignUser")]
public partial class TaskAssignUser
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TaskInfoID")]
    public long TaskInfoId { get; set; }

    public bool IsTeam { get; set; }

    [Column("MemberID")]
    public long MemberId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Createdate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TaskAssignUserCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TaskAssignUserModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("TaskInfoId")]
    [InverseProperty("TaskAssignUsers")]
    public virtual TaskInfo TaskInfo { get; set; } = null!;
}
