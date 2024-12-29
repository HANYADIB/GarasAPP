﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("InventoryItemCategory")]
public partial class InventoryItemCategory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(1000)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column("ParentCategoryID")]
    public int? ParentCategoryId { get; set; }

    public bool HaveItem { get; set; }

    public bool? IsFinalProduct { get; set; }

    public bool? IsRentItem { get; set; }

    public bool? IsAsset { get; set; }

    public bool? IsNonStock { get; set; }

    [InverseProperty("ProductGroup")]
    public virtual ICollection<Bomproduct> Bomproducts { get; set; } = new List<Bomproduct>();

    [InverseProperty("ProductGroup")]
    public virtual ICollection<Bom> Boms { get; set; } = new List<Bom>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("InventoryItemCategoryCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("InventoryItemCategory")]
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    [InverseProperty("ParentCategory")]
    public virtual ICollection<InventoryItemCategory> InverseParentCategory { get; set; } = new List<InventoryItemCategory>();

    [InverseProperty("Category")]
    public virtual ICollection<MaintenanceFor> MaintenanceFors { get; set; } = new List<MaintenanceFor>();

    [ForeignKey("ModifiedBy")]
    [InverseProperty("InventoryItemCategoryModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("ParentCategoryId")]
    [InverseProperty("InverseParentCategory")]
    public virtual InventoryItemCategory? ParentCategory { get; set; }

    [InverseProperty("InventoryItemCategory")]
    public virtual ICollection<PricingProduct> PricingProducts { get; set; } = new List<PricingProduct>();

    [InverseProperty("InventoryItemCategory")]
    public virtual ICollection<SalesOfferProduct> SalesOfferProducts { get; set; } = new List<SalesOfferProduct>();
}
