using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProjectTMAttachment")]
public partial class ProjectTmattachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ProjectTMID")]
    public long ProjectTmid { get; set; }

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtension { get; set; } = null!;

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string? Descreption { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("ProjectTmattachments")]
    public virtual AttachmentCategory? Category { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProjectTmattachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProjectTmattachmentModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("ProjectTmid")]
    [InverseProperty("ProjectTmattachments")]
    public virtual ProjectTm ProjectTm { get; set; } = null!;
}
