using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Area")]
public partial class Area
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(1000)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Column("GovernorateID")]
    public int GovernorateId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public virtual ICollection<ClientAddress> ClientAddresses { get; set; } = new List<ClientAddress>();


    [ForeignKey("GovernorateId")]
    public virtual Governorate Governorate { get; set; } = null!;

   

    
}
