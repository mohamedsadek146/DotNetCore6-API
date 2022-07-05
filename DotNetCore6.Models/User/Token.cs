using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{

    [Table("Token", Schema = "User")]
    public partial class Token : BaseModel
    {
        public Token()
        {
            Logs = new List<TokenLog>();
        }
        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [StringLength(250)]
        public string Code { get; set; }

        [Required]
        [StringLength(250)]
        public string IP { get; set; }
        public string UserAgent { get; set; }

        public DateTime ExpirationDate { get; set; }
        public DateTime? LoggedOutDate { get; set; }

        public bool Active { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TokenAction> Actions { get; set; }

        public virtual ICollection<TokenLog> Logs { get; set; }

    }
}
