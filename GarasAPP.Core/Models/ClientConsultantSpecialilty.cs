using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientConsultantSpecialilty")]
public partial class ClientConsultantSpecialilty
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ConsultantID")]
    public long ConsultantId { get; set; }

    [Column("SpecialityID")]
    public int SpecialityId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Required]
    public bool? Active { get; set; }

    [ForeignKey("ConsultantId")]
    [InverseProperty("ClientConsultantSpecialilties")]
    public virtual ClientConsultant Consultant { get; set; } = null!;

    [ForeignKey("SpecialityId")]
    [InverseProperty("ClientConsultantSpecialilties")]
    public virtual Speciality Speciality { get; set; } = null!;
}
