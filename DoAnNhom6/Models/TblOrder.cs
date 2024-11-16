using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? TotalAmount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblOrderHistory> TblOrderHistories { get; set; } = new List<TblOrderHistory>();

    public virtual ICollection<TblOrderStatus> TblOrderStatuses { get; set; } = new List<TblOrderStatus>();

    public virtual ICollection<TblPayment> TblPayments { get; set; } = new List<TblPayment>();
}
