using DotNetCore6.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{
    [Table("RoleAction", Schema = "User")]
    public class RoleAction : BaseModel
    {
        public RoleAction()
        {

        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Role")]
        public ApplicationRole RoleID { get; set; }

        public Enums.Page PageID { get; set; }
        public Enums.Action ActionID { get; set; }

        [ForeignKey("PageID, ActionID")]
        public virtual PageAction PageAction { set; get; }

        [ForeignKey("RoleID")]
        public virtual Role Role { set; get; }
    }
}