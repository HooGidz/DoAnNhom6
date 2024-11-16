using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Avatar { get; set; }

    public int? RoleId { get; set; }

    public string? LastLogin { get; set; }

    public bool IsActive { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblProductReview> TblProductReviews { get; set; } = new List<TblProductReview>();

    public virtual ICollection<TblWishList> TblWishLists { get; set; } = new List<TblWishList>();
}
