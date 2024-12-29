using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ReportCCUser")]
public partial class ReportCcuser
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ReportID")]
    public int ReportId { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ReportCcuserCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ReportId")]
    [InverseProperty("ReportCcusers")]
    public virtual Report Report { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ReportCcuserUsers")]
    public virtual User User { get; set; } = null!;
}
