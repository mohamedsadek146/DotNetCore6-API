using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{
    [Table("PageAction",Schema = "User")]
    public class PageAction : BaseModel
    {
        public PageAction()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public override int ID { get; set; }


        [ForeignKey("Page")]
        //[Key]
        //[Column(Order = 1)]
        public Models.Enums.Page PageID { get; set; }

        //[Key]
        //[Column(Order = 2)]
        public Models.Enums.Action ActionID { get; set; }

        public virtual Page Page { get; set; }

    }
}