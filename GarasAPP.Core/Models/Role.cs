using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Role")]
public partial class Role
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public long? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public bool Active { get; set; }

    [ForeignKey("CreatedBy")]
    public virtual User CreatedByNavigation { get; set; } = null;

    [ForeignKey("ModifiedBy")]
    public virtual User? ModifiedByNavigation { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
