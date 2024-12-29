using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Team")]
public partial class Team
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [Required]
    public bool? Active { get; set; }

    public string? Description { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TeamCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TeamModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [InverseProperty("Team")]
    public virtual ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

    [InverseProperty("Team")]
    public virtual ICollection<WorkshopStation> WorkshopStations { get; set; } = new List<WorkshopStation>();
}
