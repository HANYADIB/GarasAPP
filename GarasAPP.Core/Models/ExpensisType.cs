using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ExpensisType")]
public partial class ExpensisType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string ExpensisTypeName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ExpensisTypeCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ExpensisTypeModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
