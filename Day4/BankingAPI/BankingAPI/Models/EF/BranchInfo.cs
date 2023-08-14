using System;
using System.Collections.Generic;

namespace BankingAPI.Models.EF;

public partial class BranchInfo
{
    public int BranchNo { get; set; }

    public string? BranchName { get; set; }

    public string? BranchCity { get; set; }

    public virtual ICollection<AccountInfo> AccountInfos { get; set; } = new List<AccountInfo>();
}
