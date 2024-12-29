﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("TermsLibrary")]
public partial class TermsLibrary
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column("TermGroupID")]
    public int TermGroupId { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TermsLibraryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("TermsLibraryModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("TermGroupId")]
    [InverseProperty("TermsLibraries")]
    public virtual TermsGroup TermGroup { get; set; } = null!;
}
