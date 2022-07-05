using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCore6.Models.Enums;

namespace DotNetCore6.Models.User
{
    [Table("User", Schema = "User")]
    public class User : BaseModel
    {
        public User()
        {
            Tokens = new List<Token>();
        }

        //[Required]
        [MaxLength(255)]
        public string Code { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

        [Required]
        [MaxLength(250)]
        public string SaltPassword { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
        
    }
}