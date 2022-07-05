using System.Collections.Generic;
using DotNetCore6.Models.Enums;
using DotNetCore6.Models.HR;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.HR;
using DotNetCore6.ViewModels.HR.Job;
using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.Services.HR
{
    public interface IJobService
    {
        PagingViewModel<JobViewModel> Get(string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 100, Language language = Language.Arabic);
        IEnumerable<SelectListItemViewModel> GetList();
        PagingViewModel<SelectListItemViewModel> GetList(string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 100, Language language = Language.Arabic);
        JobViewModel Get(int id);
        JobEditViewModel GetEditableByID(int id);

        bool IsExists(JobCreateViewModel viewModel);
        Job Add(JobCreateViewModel viewModel);
        void Edit(JobEditViewModel viewModel);
        void Delete(int id);
        bool IsDeleted(int id);
    }
}
