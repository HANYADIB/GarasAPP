﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("VehicleBodyType")]
public partial class VehicleBodyType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int VehicleModelId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [ForeignKey("VehicleModelId")]
    [InverseProperty("VehicleBodyTypes")]
    public virtual VehicleModel VehicleModel { get; set; } = null!;

    [InverseProperty("BodyType")]
    public virtual ICollection<VehiclePerClient> VehiclePerClients { get; set; } = new List<VehiclePerClient>();
}