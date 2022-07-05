using System.ComponentModel.DataAnnotations;

namespace DotNetCore6.ViewModels.Student
{
    public class StudentViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string NationalID { get; set; }
        public int Age { get; set; }
    }
}
