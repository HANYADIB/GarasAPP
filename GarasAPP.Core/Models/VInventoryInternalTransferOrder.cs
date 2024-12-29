using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GarasAPP.Core.Models;

[Keyless]
public partial class VInventoryInternalTransferOrder
{
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(50)]
    public string OperationType { get; set; } = null!;

    public int Revision { get; set; }

    [Column("FromInventoryStoreID")]
    public int FromInventoryStoreId { get; set; }

    [Column("ToInventoryStoreID")]
    public int ToInventoryStoreId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RecivingDate { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(101)]
    public string CreatorUserName { get; set; } = null!;

    [StringLength(1000)]
    public string FromInventoryStoreName { get; set; } = null!;

    [Column("FromInventoryKeeperUserID")]
    public long FromInventoryKeeperUserId { get; set; }

    [StringLength(1000)]
    public string ToInventoryStoreName { get; set; } = null!;

    [Column("ToInventoryKeeperUserID")]
    public long ToInventoryKeeperUserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;
}
