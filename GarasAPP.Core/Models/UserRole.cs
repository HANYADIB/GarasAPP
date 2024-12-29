using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("UserRole")]
public partial class UserRole
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [Column("UserID")]
    public long? UserId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

   

    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual User User { get; set; } 
}
