using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.ViewModels.ToDo.Task
{
    public class TaskEditViewModel : TaskCreateViewModel
    {
        public int ID { set; get; }
        public bool IsDone { set; get; }
    }
}
