using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblOrderHistory
{
    public int HistoryId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual TblOrder? Order { get; set; }
}
