using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("ClientSpeciality")]
public partial class ClientSpeciality
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ClientID")]
    public long ClientId { get; set; }

    [Column("SpecialityID")]
    public int SpecialityId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    public bool Active { get; set; }

    [ForeignKey("ClientId")]
    [InverseProperty("ClientSpecialities")]
    public virtual Client Client { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ClientSpecialityCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ClientSpecialityModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }

    [ForeignKey("SpecialityId")]
    [InverseProperty("ClientSpecialities")]
    public virtual Speciality Speciality { get; set; } = null!;
}
