using System;
using System.Collections.Generic;

namespace DaihoWebAPI.TempContext;

public partial class AsmPRackMovementR
{
    public byte HistoryId { get; set; }

    public string MovementId { get; set; } = null!;

    public string CoCd { get; set; } = null!;

    public decimal? RevNo { get; set; }

    public DateTime MovementDate { get; set; }

    public string MovementStatus { get; set; } = null!;

    public string MovementType { get; set; } = null!;

    public string? MovementReason { get; set; }

    public string? ScrCompanyCd { get; set; }

    public string SrcLocCd { get; set; } = null!;

    public string SrcRackCd { get; set; } = null!;

    public string? DestCompanyCd { get; set; }

    public string DestLocCd { get; set; } = null!;

    public string DescRackCd { get; set; } = null!;

    public string? Remarks { get; set; }

    public decimal Isactived { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }
}
