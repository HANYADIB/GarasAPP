using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Group_User")]
public partial class GroupUser
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GroupID")]
    public long GroupId { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("GroupUserCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("GroupUsers")]
    public virtual Group Group { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("GroupUserUsers")]
    public virtual User User { get; set; } = null!;
}
