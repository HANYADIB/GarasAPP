using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

public partial class ContractDetail
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("ContactTypeID")]
    public int ContactTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    public int? ProbationPeriod { get; set; }

    public int? NoticedByEmployee { get; set; }

    public int? NoticedByCompany { get; set; }

    public bool IsCurrent { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public long ModifiedBy { get; set; }

    public bool IsAllowOverTime { get; set; }

    [Required]
    [Column("ISAutomatic")]
    public bool? Isautomatic { get; set; }

    [ForeignKey("ContactTypeId")]
    [InverseProperty("ContractDetails")]
    public virtual ContractType ContactType { get; set; } = null!;

    [InverseProperty("Contract")]
    public virtual ICollection<ContractLeaveEmployee> ContractLeaveEmployees { get; set; } = new List<ContractLeaveEmployee>();

    [ForeignKey("CreatedBy")]
    [InverseProperty("ContractDetailCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("ContractDetailModifiedByNavigations")]
    public virtual User ModifiedByNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ContractDetailUsers")]
    public virtual User User { get; set; } = null!;
}
