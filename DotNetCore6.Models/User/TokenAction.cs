using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{
    

    [Table("TokenAction", Schema = "User")]
    public partial class TokenAction : BaseModel
    {
        public int TokenID { get; set; }
        public int ItemID { get; set; } = 0;

        public Models.Enums.Page Page { get; set; }
        public Models.Enums.Action Action { get; set; }
        public string Title { get; set; }
        public string Data { get; set; }

        [Required]
        [StringLength(250)]
        public string IP { get; set; }

        [Required]
        [StringLength(250)]
        public string UserAgent { get; set; }

        [Required]
        [StringLength(250)]
        public string URL { get; set; }

        public virtual Token Token { get; set; }
    }
}
