using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskPrimarySubCategory")]
public partial class TaskPrimarySubCategory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("TaskCategoryID")]
    public long? TaskCategoryId { get; set; }

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
    [InverseProperty("TaskPrimarySubCategoryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TaskPrimarySubCategoryModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("TaskCategoryId")]
    [InverseProperty("TaskPrimarySubCategories")]
    public virtual TaskCategory? TaskCategory { get; set; }

    [InverseProperty("TaskPrimarySubCategory")]
    public virtual ICollection<TaskSecondarySubCategory> TaskSecondarySubCategories { get; set; } = new List<TaskSecondarySubCategory>();
}
