using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ProductGroup")]
public partial class ProductGroup
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

    [ForeignKey("CreatedBy")]
    [InverseProperty("ProductGroupCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ProductGroupModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [InverseProperty("ProductGroup")]
    public virtual ICollection<PricingProduct> PricingProducts { get; set; } = new List<PricingProduct>();

    [InverseProperty("ProductGroup")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [InverseProperty("ProductGroup")]
    public virtual ICollection<SalesOfferProduct> SalesOfferProducts { get; set; } = new List<SalesOfferProduct>();
}
