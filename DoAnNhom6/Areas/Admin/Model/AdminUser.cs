using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnNhom6.Areas.Admin.Models
{
    [Table("AdminUser")]
    public class AdminUser.Areas.Admin.Models
    {

        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
    }
}
