using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Alias { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public int? PriceSale { get; set; }

    public int? Quantity { get; set; }

    public bool IsNew { get; set; }

    public bool IsBestSeller { get; set; }

    public bool IsActive { get; set; }

    public int? Star { get; set; }

    public virtual TblProductCategory? Category { get; set; }

    public virtual ICollection<TblProductReview> TblProductReviews { get; set; } = new List<TblProductReview>();

    public virtual ICollection<TblWishList> TblWishLists { get; set; } = new List<TblWishList>();
}
