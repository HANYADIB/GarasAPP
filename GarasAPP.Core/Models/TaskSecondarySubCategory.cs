using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskSecondarySubCategory")]
public partial class TaskSecondarySubCategory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("TaskPrimarySubCategoryID")]
    public long TaskPrimarySubCategoryId { get; set; }

    [Required]
    public bool? Active { get; set; }

    public string? Description { get; set; }

    [ForeignKey("TaskPrimarySubCategoryId")]
    [InverseProperty("TaskSecondarySubCategories")]
    public virtual TaskPrimarySubCategory TaskPrimarySubCategory { get; set; } = null!;
}
