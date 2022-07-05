using DotNetCore6.Data.UnitofWork;
using System.Collections.Generic;
using System.Linq;

using DotNetCore6.Models.HR;
using DotNetCore6.ViewModels;
using AutoMapper;
using DotNetCore6.ViewModels.HR;
using AutoMapper.QueryableExtensions;
using DotNetCore6.Data.Extentions;
using DotNetCore6.Models.Enums;
using DotNetCore6.Services.Helpers;
using DotNetCore6.Data.Repository;
using DotNetCore6.ViewModels.Shared;
using DotNetCore6.ViewModels.HR.Job;

namespace DotNetCore6.Services.HR
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Job> _jobRepository;
        private readonly IMapper _mapper;

        public JobService(
            IMapper mapper,
            IRepository<Job> JobRepository, IUnitOfWork unitOfWork) : base()
        {
            _mapper = mapper;
            _jobRepository = JobRepository;
            _unitOfWork = unitOfWork;
        }
        public PagingViewModel<JobViewModel> Get(string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 100, Language language = Language.Arabic)
        {
            var query = _jobRepository.Get().OrderByPropertyName(orderBy, isAscending).ProjectTo<JobViewModel>(_mapper.ConfigurationProvider);
            return PagingHelper.Create(query, pageIndex, pageSize);
        }
        public PagingViewModel<SelectListItemViewModel> GetList(string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 100, Language language = Language.Arabic)
        {
            var query = _jobRepository.Get().OrderByPropertyName(orderBy, isAscending).ProjectTo<SelectListItemViewModel>(_mapper.ConfigurationProvider);
            return PagingHelper.Create(query, pageIndex, pageSize);
        }

        public IEnumerable<SelectListItemViewModel> GetList()
        {
            return _jobRepository.Get().ProjectTo<SelectListItemViewModel>(_mapper.ConfigurationProvider);
        }
        public JobEditViewModel GetEditableByID(int id)
        {
            return _jobRepository.Get().ProjectTo<JobEditViewModel>(_mapper.ConfigurationProvider).Where(item => item.ID == id).FirstOrDefault();
        }
        public JobViewModel Get(int id)
        {
            return _jobRepository.Get().ProjectTo<JobViewModel>(_mapper.ConfigurationProvider).Where(item => item.ID == id).FirstOrDefault();
        }


        public Job Add(JobCreateViewModel viewModel)
        {
            //var job = new Job();
            //job.Code = viewModel.Code;
            //job.NameArabic = viewModel.NameArabic;
            //_jobRepository.Add(job);

            var model = _mapper.Map<Job>(viewModel);
            return _jobRepository.Add(model); ;

        }

        public void Edit(JobEditViewModel viewModel)
        {
            _jobRepository.Update(_mapper.Map<Job>(viewModel));
        }

        public void Delete(int id)
        {
            _jobRepository.Delete(id);
        }

        public bool IsExists(JobCreateViewModel viewModel)
        {
            return _jobRepository.Any(item => item.NameArabic == viewModel.NameArabic || item.NameEnglish == viewModel.NameEnglish);
        }

        public bool IsDeleted(int id)
        {
            return _jobRepository.IsDeleted(id);
        }
    }
}
