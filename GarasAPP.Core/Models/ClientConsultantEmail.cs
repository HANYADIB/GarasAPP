using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientConsultantEmail")]
public partial class ClientConsultantEmail
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ConsultantID")]
    public long ConsultantId { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool Active { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("ClientConsultantEmails")]
    public virtual ClientConsultant Consultant { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ClientConsultantEmailCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ClientConsultantEmailModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
