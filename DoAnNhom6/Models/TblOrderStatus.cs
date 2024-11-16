using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblOrderStatus
{
    public int OrderStatusId { get; set; }

    public int? OrderId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual TblOrder? Order { get; set; }
}
