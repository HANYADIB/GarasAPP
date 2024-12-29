using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("UserSession")]
public partial class UserSession
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [StringLength(250)]
    public string ModifiedBy { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserSessions")]
    public virtual User User { get; set; } = null!;
}
