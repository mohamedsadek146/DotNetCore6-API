using AutoMapper;
using DotNetCore6.Helpers;
using DotNetCore6.Models.ToDo;

namespace DotNetCore6.ViewModels.ToDo.Task
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskCreateViewModel, Models.ToDo.Task>().ReverseMap();

            CreateMap<TaskEditViewModel, Models.ToDo.Task>().ReverseMap();
            CreateMap<Models.ToDo.Task, TaskViewModel>();

        }
    }
}
