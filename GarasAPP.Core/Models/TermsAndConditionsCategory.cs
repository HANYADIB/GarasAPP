using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TermsAndConditionsCategory")]
public partial class TermsAndConditionsCategory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TermsAndConditionsCategoryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TermsAndConditionsCategoryModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("TermsCategory")]
    public virtual ICollection<TermsAndCondition> TermsAndConditions { get; set; } = new List<TermsAndCondition>();
}
