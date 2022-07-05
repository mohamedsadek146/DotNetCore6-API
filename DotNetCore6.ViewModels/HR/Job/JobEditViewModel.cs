using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.ViewModels.HR.Job
{
    public class JobEditViewModel : BilingualViewModel
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public bool IsActive { set; get; } = true;



    }
}
