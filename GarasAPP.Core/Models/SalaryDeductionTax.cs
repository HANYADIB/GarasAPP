using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalaryDeductionTax")]
public partial class SalaryDeductionTax
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("SalaryID")]
    public long SalaryId { get; set; }

    [StringLength(250)]
    public string TaxName { get; set; } = null!;

    [Column("percentage", TypeName = "decimal(8, 2)")]
    public decimal Percentage { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Amount { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public long ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalaryDeductionTaxCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalaryDeductionTaxModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("SalaryId")]
    [InverseProperty("SalaryDeductionTaxes")]
    public virtual Salary Salary { get; set; } = null!;
}
