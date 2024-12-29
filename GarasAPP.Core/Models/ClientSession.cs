using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientSession")]
public partial class ClientSession
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ClientID")]
    public long ClientId { get; set; }

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [StringLength(250)]
    public string ModifiedBy { get; set; } = null!;

    [ForeignKey("ClientId")]
    [InverseProperty("ClientSessions")]
    public virtual Client Client { get; set; } = null!;
}
