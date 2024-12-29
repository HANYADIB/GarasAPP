using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferExpirationHistory")]
public partial class SalesOfferExpirationHistory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("SalesOfferID")]
    public long SalesOfferId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OperationDate { get; set; }

    [StringLength(50)]
    public string OperationName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public bool Active { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesOfferExpirationHistories")]
    public virtual User CreatedByNavigation { get; set; } = null!;
}
