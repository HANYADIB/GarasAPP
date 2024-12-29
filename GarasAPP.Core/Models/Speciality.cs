using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Speciality")]
public partial class Speciality
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Required]
    public bool? Active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public long CreatedBy { get; set; }

    [InverseProperty("Speciality")]
    public virtual ICollection<ClientConsultantSpecialilty> ClientConsultantSpecialilties { get; set; } = new List<ClientConsultantSpecialilty>();

    [InverseProperty("Speciality")]
    public virtual ICollection<ClientSpeciality> ClientSpecialities { get; set; } = new List<ClientSpeciality>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("SpecialityCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("SpecialityModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
