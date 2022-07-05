using DotNetCore6.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DotNetCore6.Models.ToDo
{
    [Table("Task",Schema ="ToDo")]
    public class Task : BaseModel, IDelete
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public bool IsDone { get; set; } = false;
}
}
