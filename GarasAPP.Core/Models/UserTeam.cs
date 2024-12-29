using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("UserTeam")]
public partial class UserTeam
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("TeamID")]
    public long TeamId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("UserTeamCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("UserTeamModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("TeamId")]
    [InverseProperty("UserTeams")]
    public virtual Team Team { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserTeamUsers")]
    public virtual User User { get; set; } = null!;
}
