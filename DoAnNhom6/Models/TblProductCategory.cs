using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblProductCategory
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
