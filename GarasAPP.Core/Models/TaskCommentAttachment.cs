using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TaskCommentAttachment")]
public partial class TaskCommentAttachment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CommentID")]
    public int CommentId { get; set; }

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtension { get; set; } = null!;

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string? Description { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "date")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("TaskCommentAttachments")]
    public virtual AttachmentCategory? Category { get; set; }

    [ForeignKey("CommentId")]
    [InverseProperty("TaskCommentAttachments")]
    public virtual TaskComment Comment { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("TaskCommentAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TaskCommentAttachmentModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;
}
