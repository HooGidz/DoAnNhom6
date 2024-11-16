using System;
using System.Collections.Generic;

namespace DoAnNhom6.Models;

public partial class TblMenu
{
    public int MenuId { get; set; }

    public string? Name { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }
}
