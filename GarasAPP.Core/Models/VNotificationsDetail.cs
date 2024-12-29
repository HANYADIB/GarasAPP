using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VNotificationsDetail
{
    [Column("ID")]
    public long Id { get; set; }

    public long ToUserId { get; set; }

    [StringLength(50)]
    public string? ToUserFirstName { get; set; }

    [StringLength(50)]
    public string? ToUserMiddleName { get; set; }

    [Column("ToUserFLastName")]
    [StringLength(50)]
    public string? ToUserFlastName { get; set; }

    [StringLength(500)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("URL")]
    [StringLength(500)]
    public string? Url { get; set; }

    public bool New { get; set; }

    public long? FromUserId { get; set; }

    [StringLength(50)]
    public string? FromUserFirstName { get; set; }

    [StringLength(50)]
    public string? FromUserMiddleName { get; set; }

    [StringLength(50)]
    public string? FromUserLastName { get; set; }

    public int? NotificationProcessId { get; set; }

    [StringLength(250)]
    public string? ProcessName { get; set; }
}
