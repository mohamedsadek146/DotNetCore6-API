using DotNetCore6.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DotNetCore6.Models.User
{
    [Table("UserRole", Schema = "User")]
    public class UserRole : BaseModel
    {
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [ForeignKey("Role")]
        public ApplicationRole RoleID { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }


    }
}