using DotNetCore6.Data.UnitofWork;
using System.Collections.Generic;
using System.Linq;

using DotNetCore6.Models.ToDo;
using DotNetCore6.ViewModels;
using AutoMapper;
using DotNetCore6.ViewModels.ToDo;
using AutoMapper.QueryableExtensions;
using DotNetCore6.Data.Extentions;
using DotNetCore6.Models.Enums;
using DotNetCore6.Services.Helpers;
using DotNetCore6.Data.Repository;
using DotNetCore6.ViewModels.ToDo.Task;
using Task = DotNetCore6.Models.ToDo.Task;

namespace DotNetCore6.Services.ToDo
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Task> _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(
            IMapper mapper,
            IRepository<Task> TaskRepository, IUnitOfWork unitOfWork) : base()
        {
            _mapper = mapper;
            _taskRepository = TaskRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<TaskViewModel> Get()
        {
            return _taskRepository.Get(item=>item.CreatedBy==0).ProjectTo<TaskViewModel>(_mapper.ConfigurationProvider).ToList();
        }
        public IEnumerable<TaskViewModel> GetAuthorized()
        {
            return _taskRepository.Get(item=>item.CreatedBy==_unitOfWork.UserID).ProjectTo<TaskViewModel>(_mapper.ConfigurationProvider).ToList();
        }



        public TaskEditViewModel GetEditableByID(int id)
        {
            return _taskRepository.Get().ProjectTo<TaskEditViewModel>(_mapper.ConfigurationProvider).Where(item => item.ID == id).FirstOrDefault();
        }
        public TaskViewModel Get(int id)
        {
            return _taskRepository.Get().ProjectTo<TaskViewModel>(_mapper.ConfigurationProvider).Where(item => item.ID == id).FirstOrDefault();
        }


        public Task Add(TaskCreateViewModel viewModel)
        {
            //var task = new Task();
            //task.Code = viewModel.Code;
            //task.NameArabic = viewModel.NameArabic;
            //_taskRepository.Add(task);

            var model = _mapper.Map<Task>(viewModel);
            //model.CreatedBy=_un
            return _taskRepository.Add(model); ;

        }

        public void Edit(TaskEditViewModel viewModel)
        {
            _taskRepository.Update(_mapper.Map<Task>(viewModel));
        }

        public void Delete(int id)
        {
            _taskRepository.Delete(id);
        }

        public bool IsExists(TaskCreateViewModel viewModel)
        {
            return _taskRepository.Any(item => item.Title == viewModel.Title&& !item.IsDone);
        }

        public bool IsDeleted(int id)
        {
            return _taskRepository.IsDeleted(id);
        }
    }
}
