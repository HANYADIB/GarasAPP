using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("BOMLibrary")]
public partial class Bomlibrary
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Column("ProductID")]
    public long ProductId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }

    [Column("CurrencyID")]
    public int CurrencyId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal MaterialTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal FabricationTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal InstalltionTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal ProfitTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TaxTotal { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal OtherTotal { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Required]
    public bool? Global { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("BomlibraryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CurrencyId")]
    [InverseProperty("Bomlibraries")]
    public virtual Currency Currency { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("BomlibraryModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Bomlibraries")]
    public virtual Product Product { get; set; } = null!;
}
