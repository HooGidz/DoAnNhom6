using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblWishList
{
    public int WishWistId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? UpDateAt { get; set; }

    public virtual TblProduct? Product { get; set; }

    public virtual TblUser? User { get; set; }
}
