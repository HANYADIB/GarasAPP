using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientPaymentTerm")]
public partial class ClientPaymentTerm
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public long ClientId { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Percentage { get; set; }

    public string? Time { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ClientPaymentTerms")]
    public virtual Client Client { get; set; } = null!;
}
