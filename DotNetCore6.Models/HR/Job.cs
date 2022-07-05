using DotNetCore6.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.HR
{
    [Table("Job",Schema ="HR")]
    public class Job : BaseModel, IBilingual, IActive,IDisplayOrder, IDelete
    {
        [MaxLength(255)]
        public string Code { get; set; }

        [Required]
        [MaxLength(255)]
        public string NameArabic { get; set; }

        [Required]
        [MaxLength(255)]
        public string NameEnglish { get; set; }
        
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 1;
}
}
