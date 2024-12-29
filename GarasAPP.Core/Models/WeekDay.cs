using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class WeekDay
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Day { get; set; }

    [InverseProperty("DayNavigation")]
    public virtual ICollection<WorkingHour> WorkingHours { get; set; } = new List<WorkingHour>();
}
