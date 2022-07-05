using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore6.Data.UnitofWork;
using DotNetCore6.Localization.Shared;
using DotNetCore6.Services.ToDo;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.ToDo;
using DotNetCore6.ViewModels.Shared;
using DotNetCore6.Models.ToDo;
using DotNetCore6.API.Helpers;
using DotNetCore6.API.Filters;
using DotNetCore6.ViewModels.ToDo.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore6.API.Controllers.ToDo
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaskController : BaseController
    {
        private readonly ITaskService _taskService;
        private readonly IUnitOfWork _unitOfWork;

        public TaskController(ITaskService taskService, IUnitOfWork unitOfWork)
        {
            _taskService = taskService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public ResponseViewModel<IEnumerable<TaskViewModel>> GetAuthorized()
        {
            return new ResponseViewModel<IEnumerable<TaskViewModel>>(_taskService.GetAuthorized());
        }

        [HttpGet]
        //[Authorize]
        public ResponseViewModel<IEnumerable<TaskViewModel>> Get()
        {
            return new ResponseViewModel<IEnumerable<TaskViewModel>>(_taskService.Get());
        }

        [HttpGet]
        //[Authorize]
        public ResponseViewModel<TaskEditViewModel> GetEditableByID(int id)
        {
            return new ResponseViewModel<TaskEditViewModel>(_taskService.GetEditableByID(id));
        }

        [HttpGet]
        //[Authorize]
        public ResponseViewModel<TaskViewModel> GetByID(int id)
        {
            return new ResponseViewModel<TaskViewModel>(_taskService.Get(id));
        }

        


        [HttpPost]
        [ValidateViewModel]
        //[Authorize]
        public ResponseViewModel<int> POST(TaskCreateViewModel viewModel)
        {
           var task= _taskService.Add(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<int>(task.ID, Resource.SuccessfullyCreated );
        }

        [HttpPut]
        [ValidateViewModel]
        //[Authorize]
        public ResponseViewModel<bool> PUT(TaskEditViewModel viewModel)
        {
            _taskService.Edit(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyUpdated);
        }

        [HttpDelete]
        //[Authorize]
        public ResponseViewModel<bool> Delete(int id)
        {
            _taskService.Delete(id);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyDeleted);
        }

    }
}
