﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Salary")]
public partial class Salary
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("PaymentStrategyID")]
    public int PaymentStrategyId { get; set; }

    [Column("PaymentMethodID")]
    public int PaymentMethodId { get; set; }

    [StringLength(50)]
    public string? OtherPaymentMethod { get; set; }

    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal BasicSalary { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal VariantSalary { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal TotalGross { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PerHour { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal TotalNet { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal TotalIncome { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal TaxValue { get; set; }

    public bool Allownces { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public long ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalaryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("Salaries")]
    public virtual Currency Currency { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalaryModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("Salaries")]
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;

    [ForeignKey("PaymentStrategyId")]
    [InverseProperty("Salaries")]
    public virtual PaymentStrategy PaymentStrategy { get; set; } = null!;

    [InverseProperty("Salary")]
    public virtual ICollection<SalaryAllownce> SalaryAllownces { get; set; } = new List<SalaryAllownce>();

    [InverseProperty("Salary")]
    public virtual ICollection<SalaryDeductionTax> SalaryDeductionTaxes { get; set; } = new List<SalaryDeductionTax>();

    [InverseProperty("Salary")]
    public virtual ICollection<SalaryInsurance> SalaryInsurances { get; set; } = new List<SalaryInsurance>();

    [ForeignKey("UserId")]
    [InverseProperty("SalaryUsers")]
    public virtual User User { get; set; } = null!;
}