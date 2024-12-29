using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SupplierPhone")]
public partial class SupplierPhone
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("SupplierID")]
    public long SupplierId { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool Active { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SupplierPhoneCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SupplierPhoneModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("SupplierPhones")]
    public virtual Supplier Supplier { get; set; } = null!;
}
