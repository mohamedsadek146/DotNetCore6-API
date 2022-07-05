using AutoMapper;
using DotNetCore6.Helpers;
using DotNetCore6.Models.Interfaces;
using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.ViewModels.AutoMapper
{
    public class SharedProfile : Profile
    {
        public SharedProfile()
        {
            CreateMap<IBilingual, SelectListItemViewModel>()
                      .ForMember(destination => destination.Name,
                    opts => opts.MapFrom(source => LanguageHelper.IsArabic() ? source.NameArabic : source.NameEnglish));
            CreateMap<ISingleLanguage, SelectListItemViewModel>()
                     .ForMember(destination => destination.Name,
                   opts => opts.MapFrom(source => source.Name));


            CreateMap<int, IDelete>()
                .ForMember(destination => destination.ID,
                    opts => opts.MapFrom(source => source));

            CreateMap<ActivateViewModel, IActive>().ReverseMap();
            CreateMap<DisplayOrderViewModel, IDisplayOrder>().ReverseMap();


        }
    }
}
