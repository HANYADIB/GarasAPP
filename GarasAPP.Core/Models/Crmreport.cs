using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("CRMReport")]
public partial class Crmreport
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("CRMUserID")]
    public long CrmuserId { get; set; }

    [Column("BranchID")]
    public int BranchId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReportDate { get; set; }

    [Column("ClientContactPersonID")]
    public long ClientContactPersonId { get; set; }

    public bool IsNew { get; set; }

    [Column("CRMContactTypeID")]
    public int? CrmcontactTypeId { get; set; }

    [StringLength(250)]
    public string? OtherContactName { get; set; }

    [Column("CRMRecievedTypeID")]
    public int? CrmrecievedTypeId { get; set; }

    [StringLength(250)]
    public string? OtherRecievedName { get; set; }

    [Column("CRMReportReasonID")]
    public int CrmreportReasonId { get; set; }

    public string Comment { get; set; } = null!;

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    public long? ModifiedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CustomerSatisfaction { get; set; }

    [ForeignKey("BranchId")]
    [InverseProperty("Crmreports")]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey("ClientContactPersonId")]
    [InverseProperty("Crmreports")]
    public virtual ClientContactPerson ClientContactPerson { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("CrmreportCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("CrmcontactTypeId")]
    [InverseProperty("Crmreports")]
    public virtual CrmcontactType? CrmcontactType { get; set; }

    [ForeignKey("CrmrecievedTypeId")]
    [InverseProperty("Crmreports")]
    public virtual CrmrecievedType? CrmrecievedType { get; set; }

    [ForeignKey("CrmreportReasonId")]
    [InverseProperty("Crmreports")]
    public virtual CrmreportReason CrmreportReason { get; set; } = null!;

    [ForeignKey("CrmuserId")]
    [InverseProperty("CrmreportCrmusers")]
    public virtual User Crmuser { get; set; } = null!;

    [ForeignKey("ModifiedBy")]
    [InverseProperty("CrmreportModifiedByNavigations")]
    public virtual User? ModifiedByNavigation { get; set; }
}
