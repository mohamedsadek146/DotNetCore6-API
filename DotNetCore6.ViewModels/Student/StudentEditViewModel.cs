using DotNetCore6.ViewModels.Shared;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore6.ViewModels.Student
{
    public class StudentEditViewModel : BilingualViewModel
    {
        public int ID { set; get; }
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

        public int Age { get; set; }

    }
}
