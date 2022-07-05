using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore6.Data.UnitofWork;
using DotNetCore6.Localization.Shared;
using DotNetCore6.Services.HR;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.HR;
using DotNetCore6.ViewModels.Shared;
using DotNetCore6.Models.HR;
using DotNetCore6.API.Helpers;
using DotNetCore6.API.Filters;
using DotNetCore6.ViewModels.HR.Job;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore6.API.Controllers.HR
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class JobController : BaseController
    {
        private readonly IJobService _jobService;
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IJobService jobService, IUnitOfWork unitOfWork)
        {
            _jobService = jobService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public ResponseViewModel<PagingViewModel<JobViewModel>> Get(string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 2)
        {
            return new ResponseViewModel<PagingViewModel<JobViewModel>>(_jobService.Get(orderBy: orderBy, isAscending: isAscending, pageIndex: pageIndex, pageSize: pageSize));
        }

        [HttpGet]
        [Authorize]
        public ResponseViewModel<JobEditViewModel> GetEditableByID(int id)
        {
            return new ResponseViewModel<JobEditViewModel>(_jobService.GetEditableByID(id));
        }

        [HttpGet]
        [Authorize]
        public ResponseViewModel<JobViewModel> GetByID(int id)
        {
            return new ResponseViewModel<JobViewModel>(_jobService.Get(id));
        }

        [HttpPost]
        [ValidateViewModel]
        [Authorize]
        public ResponseViewModel<int> Create(Job viewModel)
        {
            //int jobID = _jobService.Add(viewModel).ID;
            //_unitOfWork.Save();
            return new ResponseViewModel<int>(1, Resource.SuccessfullyCreated);
        }


        [HttpPost]
        [ValidateViewModel]
        [Authorize]
        public ResponseViewModel<bool> POST(JobCreateViewModel viewModel)
        {
            _jobService.Add(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true,Resource.SuccessfullyCreated );
        }

        [HttpPut]
        [ValidateViewModel]
        [Authorize]
        public ResponseViewModel<bool> PUT(JobEditViewModel viewModel)
        {
            _jobService.Edit(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyUpdated);
        }

        [HttpDelete]
        [Authorize]
        public ResponseViewModel<bool> Delete(int id)
        {
            _jobService.Delete(id);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyDeleted);
        }

    }
}
