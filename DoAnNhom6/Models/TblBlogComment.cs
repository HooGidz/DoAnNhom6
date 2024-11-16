using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblBlogComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? BlogId { get; set; }

    public bool IsActive { get; set; }

    public virtual TblBlog? Blog { get; set; }
}
