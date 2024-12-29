﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectInstallationJobTitle")]
public partial class ProjectInstallationJobTitle
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("JobTitleID")]
    public int JobTitleId { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public int DisplyOrder { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectInstallationJobTitleCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("JobTitleId")]
    [InverseProperty("ProjectInstallationJobTitles")]
    public virtual JobTitle JobTitle { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectInstallationJobTitleModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
