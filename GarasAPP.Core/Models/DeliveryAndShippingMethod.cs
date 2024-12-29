using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("DeliveryAndShippingMethod")]
public partial class DeliveryAndShippingMethod
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [InverseProperty("DefaultDelivaryAndShippingMethod")]
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    [InverseProperty("DefaultDelivaryAndShippingMethod")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
