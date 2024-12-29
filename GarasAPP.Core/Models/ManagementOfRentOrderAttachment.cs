using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ManagementOfRentOrderAttachment")]
public partial class ManagementOfRentOrderAttachment
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ManagementOfRentOrderID")]
    public long ManagementOfRentOrderId { get; set; }

    [StringLength(1000)]
    public string AttachmentPath { get; set; } = null!;

    [StringLength(250)]
    public string FileName { get; set; } = null!;

    [StringLength(5)]
    public string FileExtenssion { get; set; } = null!;

    [StringLength(250)]
    public string? Category { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ManagementOfRentOrderAttachmentCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ManagementOfRentOrderId")]
    [InverseProperty("ManagementOfRentOrderAttachments")]
    public virtual ManagementOfRentOrder ManagementOfRentOrder { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ManagementOfRentOrderAttachmentModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
