using System;

namespace DotNetCore6.ViewModels.ToDo.Task
{
    public class TaskViewModel
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public bool IsDone { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
