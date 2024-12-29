using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VInventoryCategory
{
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(1000)]
    public string Name { get; set; } = null!;

    [Column("ParentCategoryID")]
    public int? ParentCategoryId { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public bool Active { get; set; }

    public bool HaveItem { get; set; }

    public string? Description { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }
}
