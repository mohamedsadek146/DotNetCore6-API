using System.Collections.Generic;
using DotNetCore6.Models;
using DotNetCore6.Models.Enums;
using DotNetCore6.Models.ToDo;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.Student;
using DotNetCore6.ViewModels.ToDo;

namespace DotNetCore6.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentViewModel> Get();
        StudentViewModel Get(int id);
        StudentEditViewModel GetEditableByID(int id);

        bool IsExists(StudentCreateViewModel viewModel);
        Student Add(StudentCreateViewModel viewModel);
        void Edit(StudentEditViewModel viewModel);
        void Delete(int id);
        bool IsDeleted(int id);
        IEnumerable<StudentViewModel> GetAuthorized();
    }
}
