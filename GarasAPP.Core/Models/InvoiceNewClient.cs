using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InvoiceNewClient")]
public partial class InvoiceNewClient
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    [StringLength(100)]
    public string? Mobile { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(250)]
    public string? WebSite { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("InvoiceNewClients")]
    public virtual User CreatedByNavigation { get; set; } = null!;
}
