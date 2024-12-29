using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectWorkshopStation")]
public partial class ProjectWorkshopStation
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long WorkshopStationId { get; set; }

    public long ProjectId { get; set; }

    public int Sequence { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ProjectWorkshopStations")]
    public virtual Project Project { get; set; } = null!;

    [InverseProperty("ProjectWorkshopStation")]
    public virtual ICollection<ProjectFabricationWorkshopStationHistory> ProjectFabricationWorkshopStationHistories { get; set; } = new List<ProjectFabricationWorkshopStationHistory>();

    [ForeignKey("WorkshopStationId")]
    [InverseProperty("ProjectWorkshopStations")]
    public virtual WorkshopStation WorkshopStation { get; set; } = null!;
}
