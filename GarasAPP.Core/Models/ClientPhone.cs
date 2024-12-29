using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientPhone")]
public partial class ClientPhone
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ClientID")]
    public long ClientId { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool Active { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ClientPhones")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ClientPhoneCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ClientPhoneModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
