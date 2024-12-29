using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("DailyJournalEntryReverse")]
public partial class DailyJournalEntryReverse
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ParentDJEntryId")]
    public long ParentDjentryId { get; set; }

    [Column("DJEntryId")]
    public long DjentryId { get; set; }

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModificationDate { get; set; }

    public long ModifiedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("DailyJournalEntryReverseCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("DjentryId")]
    [InverseProperty("DailyJournalEntryReverseDjentries")]
    public virtual DailyJournalEntry Djentry { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("DailyJournalEntryReverseModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("ParentDjentryId")]
    [InverseProperty("DailyJournalEntryReverseParentDjentries")]
    public virtual DailyJournalEntry ParentDjentry { get; set; } = null!;
}
