﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class ClientAccount
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("DailyAdjustingEntryID")]
    public long DailyAdjustingEntryId { get; set; }

    [Column("ClientID")]
    public long ClientId { get; set; }

    [Column("ProjectID")]
    public long? ProjectId { get; set; }

    [Column("AccountID")]
    public long AccountId { get; set; }

    [StringLength(50)]
    public string AccountType { get; set; } = null!;

    [StringLength(50)]
    public string AmountSign { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Column("AccountOfJEId")]
    public long? AccountOfJeid { get; set; }

    [Column("OfferID")]
    public long? OfferId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("ClientAccounts")]
    public virtual Account Account { get; set; } = null!;

    [ForeignKey("AccountOfJeid")]
    [InverseProperty("ClientAccounts")]
    public virtual AccountOfJournalEntry? AccountOfJe { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ClientAccounts")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ClientAccountCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ClientAccountModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("OfferId")]
    [InverseProperty("ClientAccounts")]
    public virtual SalesOffer? Offer { get; set; }

    [ForeignKey("ProjectId")]
    [InverseProperty("ClientAccounts")]
    public virtual Project? Project { get; set; }
}