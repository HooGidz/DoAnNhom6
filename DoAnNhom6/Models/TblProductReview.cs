using System;
using System.Collections.Generic;
namespace DoAnNhom6.Models;

    public partial class TblProductReview
    {
        public int ProductReviewId { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? Detail { get; set; }

        public int? Star { get; set; }

        public bool IsActive { get; set; }

        public virtual TblProduct? Product { get; set; }

        public virtual TblUser? User { get; set; }
    }

