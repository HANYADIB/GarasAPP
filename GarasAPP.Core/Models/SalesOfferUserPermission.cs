﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("SalesOfferUserPermission")]
public partial class SalesOfferUserPermission
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("OfferID")]
    public long OfferId { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("PermissionID")]
    public int PermissionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long CreatedBy { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Required]
    public bool? Active { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SalesOfferUserPermissionCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SalesOfferUserPermissionModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("OfferId")]
    [InverseProperty("SalesOfferUserPermissions")]
    public virtual SalesOffer Offer { get; set; } = null!;

    [ForeignKey("PermissionId")]
    [InverseProperty("SalesOfferUserPermissions")]
    public virtual PermissionLevel Permission { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("SalesOfferUserPermissionUsers")]
    public virtual User User { get; set; } = null!;
}
