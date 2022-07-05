using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCore6.Data.UnitofWork;
using DotNetCore6.Localization.Shared;
using DotNetCore6.Services.ToDo;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.ToDo;
using DotNetCore6.ViewModels.Shared;
using DotNetCore6.Models.ToDo;
using DotNetCore6.API.Helpers;
using DotNetCore6.API.Filters;
using DotNetCore6.Services;
using DotNetCore6.ViewModels.Student;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore6.API.Controllers.ToDo
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IStudentService studentService, IUnitOfWork unitOfWork)
        {
            _studentService = studentService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public ResponseViewModel<IEnumerable<StudentViewModel>> GetAuthorized()
        {
            return new ResponseViewModel<IEnumerable<StudentViewModel>>(_studentService.GetAuthorized());
        }

        [HttpGet]
        //[Authorize]
        public ResponseViewModel<IEnumerable<StudentViewModel>> Get()
        {
            return new ResponseViewModel<IEnumerable<StudentViewModel>>(_studentService.Get());
        }

        [HttpGet]
        //[Authorize]
        public ResponseViewModel<StudentEditViewModel> GetEditableByID(int id)
        {
            return new ResponseViewModel<StudentEditViewModel>(_studentService.GetEditableByID(id));
        }

        [HttpGet]
        //[Authorize]
        public ResponseViewModel<StudentViewModel> GetByID(int id)
        {
            return new ResponseViewModel<StudentViewModel>(_studentService.Get(id));
        }

        


        [HttpPost]
        [ValidateViewModel]
        //[Authorize]
        public ResponseViewModel<int> POST(StudentCreateViewModel viewModel)
        {
            if(_studentService.IsExists(viewModel))
                return new ResponseViewModel<int>(0, Resource.AlreadyExists,success:false);

            var student = _studentService.Add(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<int>(student.ID, Resource.SuccessfullyCreated );
        }

        [HttpPut]
        [ValidateViewModel]
        //[Authorize]
        public ResponseViewModel<bool> PUT(StudentEditViewModel viewModel)
        {
            _studentService.Edit(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyUpdated);
        }

        [HttpDelete]
        //[Authorize]
        public ResponseViewModel<bool> Delete(int id)
        {
            _studentService.Delete(id);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyDeleted);
        }

    }
}
