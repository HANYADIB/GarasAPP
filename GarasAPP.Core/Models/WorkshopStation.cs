using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("WorkshopStation")]
public partial class WorkshopStation
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(100)]
    public string StationName { get; set; } = null!;

    [StringLength(200)]
    public string? Location { get; set; }

    public int? BranchId { get; set; }

    public long? TeamId { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("WorkshopStations")]
    public virtual Branch? Branch { get; set; }

    [InverseProperty("WorkshopStation")]
    public virtual ICollection<ProjectWorkshopStation> ProjectWorkshopStations { get; set; } = new List<ProjectWorkshopStation>();

    [ForeignKey("TeamId")]
    [InverseProperty("WorkshopStations")]
    public virtual Team? Team { get; set; }
}
