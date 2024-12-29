using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("BundleModule")]
public partial class BundleModule
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string BundleOrModuleName { get; set; } = null!;

    [Column("ParentID")]
    public int? ParentId { get; set; }

    public bool Active { get; set; }

    public long? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }
}
