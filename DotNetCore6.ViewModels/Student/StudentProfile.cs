using AutoMapper;
using DotNetCore6.Helpers;
using DotNetCore6.Models.HR;

namespace DotNetCore6.ViewModels.Student
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentCreateViewModel, Models.Student>().ReverseMap();

            CreateMap<StudentEditViewModel, Models.Student>().ReverseMap();
            CreateMap<Models.Student, StudentViewModel>()

                      .ForMember(destination => destination.Name,
                    opts => opts.MapFrom(source => source.FirstName + " " + source.LastName)); ;
            ;


        }
    }
}
