using System;
using System.Collections.Generic;

namespace BankingAPI.Models.EF;

public partial class AccountInfo
{
    public int AccountNo { get; set; }

    public string? AccountName { get; set; }

    public decimal? AccountBalnce { get; set; }

    public bool? AccountIsActive { get; set; }

    public int? AccountBranch { get; set; }

    public virtual BranchInfo? AccountBranchNavigation { get; set; }

    public virtual ICollection<TransactionInfo> TransactionInfoTransactionFromAccNavigations { get; set; } = new List<TransactionInfo>();

    public virtual ICollection<TransactionInfo> TransactionInfoTransactionToAccNavigations { get; set; } = new List<TransactionInfo>();
}
