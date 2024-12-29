using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("EmployeeID")]
    public long EmployeeId { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [Column("TeamID")]
    public long? TeamId { get; set; }

    [Column(TypeName = "date")]
    public DateTime AttendanceDate { get; set; }

    public int? CheckInHour { get; set; }

    public int? CheckInMin { get; set; }

    public int? CheckOutHour { get; set; }

    public int? CheckOutMin { get; set; }

    public int? NoHours { get; set; }

    public int? NoMin { get; set; }

    public int? DelayHours { get; set; }

    public int? DelayMin { get; set; }

    public int? OverTimeHour { get; set; }

    public int? OverTimeMin { get; set; }

    [Column("AbsenceTypeID")]
    public int? AbsenceTypeId { get; set; }

    public bool? IsApprovedAbsence { get; set; }

    [Column("ApprovedByUserID")]
    public long? ApprovedByUserId { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreationDate { get; set; }

    public long ModifiedBy { get; set; }

    [Column(TypeName = "date")]
    public DateTime ModificationDate { get; set; }

    [Required]
    public bool? Active { get; set; }

    [ForeignKey("AbsenceTypeId")]
    [InverseProperty("Attendances")]
    public virtual ContractLeaveSetting? AbsenceType { get; set; }
}
