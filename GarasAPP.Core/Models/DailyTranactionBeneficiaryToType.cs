﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("DailyTranactionBeneficiaryToType")]
public partial class DailyTranactionBeneficiaryToType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string BeneficiaryName { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("DailyTranactionBeneficiaryToTypeCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("BeneficiaryType")]
    public virtual ICollection<DailyTranactionBeneficiaryToUser> DailyTranactionBeneficiaryToUsers { get; set; } = new List<DailyTranactionBeneficiaryToUser>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("DailyTranactionBeneficiaryToTypeModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}