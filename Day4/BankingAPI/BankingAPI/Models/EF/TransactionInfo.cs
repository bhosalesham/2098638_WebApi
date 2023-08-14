using System;
using System.Collections.Generic;

namespace BankingAPI.Models.EF;

public partial class TransactionInfo
{
    public int TransactionNo { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? TransactionFromAcc { get; set; }

    public int? TransactionToAcc { get; set; }

    public decimal? TransactionAmount { get; set; }

    public string? TransactionStatus { get; set; }

    public virtual AccountInfo? TransactionFromAccNavigation { get; set; }

    public virtual AccountInfo? TransactionToAccNavigation { get; set; }
}
