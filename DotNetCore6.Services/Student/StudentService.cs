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
using DotNetCore6.Models;
using DotNetCore6.ViewModels.Student;

namespace DotNetCore6.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(
            IMapper mapper,
            IRepository<Student> StudentRepository, IUnitOfWork unitOfWork) : base()
        {
            _mapper = mapper;
            _studentRepository = StudentRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<StudentViewModel> Get()
        {
            return _studentRepository.Get(item=>item.CreatedBy==0).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToList();
        }
        public IEnumerable<StudentViewModel> GetAuthorized()
        {
            return _studentRepository.Get(item=>item.CreatedBy==_unitOfWork.UserID).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).ToList();
        }



        public StudentEditViewModel GetEditableByID(int id)
        {
            return _studentRepository.Get().ProjectTo<StudentEditViewModel>(_mapper.ConfigurationProvider).Where(item => item.ID == id).FirstOrDefault();
        }
        public StudentViewModel Get(int id)
        {
            return _studentRepository.Get().ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider).Where(item => item.ID == id).FirstOrDefault();
        }


        public Student Add(StudentCreateViewModel viewModel)
        {
            //var student = new Student();
            //student.Code = viewModel.Code;
            //student.NameArabic = viewModel.NameArabic;
            //_studentRepository.Add(student);

            var model = _mapper.Map<Student>(viewModel);
            //model.CreatedBy=_un
            return _studentRepository.Add(model); ;

        }

        public void Edit(StudentEditViewModel viewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(viewModel));
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }

        public bool IsExists(StudentCreateViewModel viewModel)
        {
            return _studentRepository.Any(item => item.FirstName == viewModel.FirstName&& item.LastName == viewModel.LastName);
        }

        public bool IsDeleted(int id)
        {
            return _studentRepository.IsDeleted(id);
        }
    }
}
