using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("EInvoiceCompanyActivity")]
public partial class EinvoiceCompanyActivity
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string Code { get; set; } = null!;

    [StringLength(250)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModificationDate { get; set; }
}
