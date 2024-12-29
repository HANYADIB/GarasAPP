using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("GarasClientInfo")]
public partial class GarasClientInfo
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    public byte[]? Logo { get; set; }

    public string? Description { get; set; }

    [Column("SpecialtyID")]
    public int? SpecialtyId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("GarasClientInfoCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("GarasClientInfoModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;
}
