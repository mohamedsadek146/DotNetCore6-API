using DotNetCore6.Models.Enums;
using DotNetCore6.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{
    [Table("Role", Schema = "User")]
    public class Role : BaseModel, IBilingual, IActive
    {
        public Role()
        {
            Users = new List<User>();
            Actions = new List<RoleAction>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ApplicationRole ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameArabic { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameEnglish { get; set; }

        [Required]
        [MaxLength(250)]
        public string RedirectUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDevelopment { get; set; } = false;
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<RoleAction> Actions { get; set; }

    }
}