using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblPayment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual TblOrder? Order { get; set; }
}
