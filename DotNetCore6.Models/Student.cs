using DotNetCore6.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models
{
    [Table("Student", Schema = "Student")]
    public class Student : BaseModel, IDelete
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Mobile { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string NationalID { get; set; }

        public int Age { get; set; } = 0;


    }
}
