using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Country")]
public partial class Country
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? CreatedBy { get; set; }

    [Column("OldID")]
    public int? OldId { get; set; }

    public virtual ICollection<ClientAddress> ClientAddresses { get; set; } = new List<ClientAddress>();

    public virtual ICollection<Governorate> Governorates { get; set; } = new List<Governorate>();

}
