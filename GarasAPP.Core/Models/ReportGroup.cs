﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ReportGroup")]
public partial class ReportGroup
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ReportID")]
    public int ReportId { get; set; }

    [Column("GroupID")]
    public long GroupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ReportGroups")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("ReportGroups")]
    public virtual Group Group { get; set; } = null!;

    [ForeignKey("ReportId")]
    [InverseProperty("ReportGroups")]
    public virtual Report Report { get; set; } = null!;
}