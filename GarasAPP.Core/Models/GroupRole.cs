using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("GroupRole")]
public partial class GroupRole
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [Column("GroupID")]
    public long GroupId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("GroupRoles")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("GroupRoles")]
    public virtual Group Group { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("GroupRoles")]
    public virtual Role Role { get; set; } = null!;
}
