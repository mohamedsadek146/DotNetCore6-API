using System.Collections.Generic;
using DotNetCore6.Models.Enums;
using DotNetCore6.Models.ToDo;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.ToDo;
using DotNetCore6.ViewModels.ToDo.Task;
using Task = DotNetCore6.Models.ToDo.Task;

namespace DotNetCore6.Services.ToDo
{
    public interface ITaskService
    {
        IEnumerable<TaskViewModel> Get();
        TaskViewModel Get(int id);
        TaskEditViewModel GetEditableByID(int id);

        bool IsExists(TaskCreateViewModel viewModel);
        Task Add(TaskCreateViewModel viewModel);
        void Edit(TaskEditViewModel viewModel);
        void Delete(int id);
        bool IsDeleted(int id);
        IEnumerable<TaskViewModel> GetAuthorized();
    }
}
