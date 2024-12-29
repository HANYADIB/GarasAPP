using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("HREmployeeAttachment")]
public partial class HremployeeAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("EmployeeUserID")]
    public long EmployeeUserId { get; set; }

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(250)]
    public string FileExtention { get; set; } = null!;

    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string CategoryName { get; set; } = null!;

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ExpiredDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public long ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("HremployeeAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("EmployeeUserId")]
    [InverseProperty("HremployeeAttachmentEmployeeUsers")]
    public virtual User EmployeeUser { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("HremployeeAttachmentModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;
}
