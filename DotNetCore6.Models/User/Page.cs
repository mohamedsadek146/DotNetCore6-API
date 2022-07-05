using DotNetCore6.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.User
{
    [Table("Page",Schema = "User")]
    public class Page : BaseModel, IBilingual,IActive
    {
        public Page()
        {
            Actions = new List<PageAction>();
            RoleActions= new List<RoleAction>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Models.Enums.Page ID { get; set; }
        [ForeignKey("Module")]
        public int ModuleID { get; set; }
        public int? ParentPageID { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameArabic { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameEnglish { get; set; }

        public int DisplayOrder { get; set; } = 1;
        public string Icon { get; set; }

        [Required]
        [MaxLength(250)]
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<PageAction> Actions { get; set; }
        public virtual ICollection<RoleAction> RoleActions { get; set; }
    }
}