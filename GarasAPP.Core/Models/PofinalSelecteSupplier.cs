using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("POFinalSelecteSupplier")]
public partial class PofinalSelecteSupplier
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("POID")]
    public long Poid { get; set; }

    [Column("ContactThroughID")]
    public int ContactThroughId { get; set; }

    public string? ClientEmailFrom { get; set; }

    [Column("SupplierContactPersonID")]
    public long? SupplierContactPersonId { get; set; }

    public string? SupplietEmailTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RemindDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(250)]
    public string CreatedBy { get; set; } = null!;

    [ForeignKey("ContactThroughId")]
    [InverseProperty("PofinalSelecteSuppliers")]
    public virtual ContactThrough ContactThrough { get; set; } = null!;

    [ForeignKey("Poid")]
    [InverseProperty("PofinalSelecteSuppliers")]
    public virtual PurchasePo Po { get; set; } = null!;

    [ForeignKey("SupplierContactPersonId")]
    [InverseProperty("PofinalSelecteSuppliers")]
    public virtual SupplierContactPerson? SupplierContactPerson { get; set; }
}
