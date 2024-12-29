using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("AccountFinancialPeriodAttachment")]
public partial class AccountFinancialPeriodAttachment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("FinancalPeriodID")]
    public int FinancalPeriodId { get; set; }

    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtenssion { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
