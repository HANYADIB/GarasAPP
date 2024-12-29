﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientConsultantPhone")]
public partial class ClientConsultantPhone
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ConsultantID")]
    public long ConsultantId { get; set; }

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool Active { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("ClientConsultantPhones")]
    public virtual ClientConsultant Consultant { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ClientConsultantPhoneCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ClientConsultantPhoneModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}