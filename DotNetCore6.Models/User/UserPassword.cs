using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{
 

    [Table("UserPassword", Schema = "User")]
    public partial class UserPassword : BaseModel
    {
        public UserPassword()
        {
        }

       
        [ForeignKey("User")]
        public int UserID { get; set; }
       
        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        public string IP { get; set; }

        [Required]
        [StringLength(250)]
        public string UserAgent { get; set; }
        public DateTime? NotificationSent { get; set; }

        public virtual User User { get; set; }

        
    }
}
