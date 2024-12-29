using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Table("BankDetail")]
public partial class BankDetail
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(50)]
    public string BankName { get; set; } = null!;

    [StringLength(50)]
    public string AccountHolder { get; set; } = null!;

    [StringLength(50)]
    public string AccountNumber { get; set; } = null!;

    [StringLength(50)]
    public string BankBranch { get; set; } = null!;

    [StringLength(50)]
    public string? ExpiryDate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("BankDetails")]
    public virtual User User { get; set; } = null!;
}
