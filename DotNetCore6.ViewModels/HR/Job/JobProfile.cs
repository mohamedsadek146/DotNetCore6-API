using AutoMapper;
using DotNetCore6.Helpers;
using DotNetCore6.Models.HR;

namespace DotNetCore6.ViewModels.HR.Job
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobCreateViewModel, Models.HR.Job>().ReverseMap();

            CreateMap<JobEditViewModel, Models.HR.Job>().ReverseMap();
            CreateMap<Models.HR.Job, JobViewModel>()
                      .ForMember(destination => destination.Name,
                    opts => opts.MapFrom(source => LanguageHelper.IsArabic() ? source.NameArabic : source.NameEnglish)); ;

        }
    }
}
