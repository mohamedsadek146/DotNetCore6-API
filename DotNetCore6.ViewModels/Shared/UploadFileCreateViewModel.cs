using Microsoft.AspNetCore.Http;

namespace DotNetCore6.ViewModels.Shared
{
    public class UploadFileCreateViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public IFormFile File { set; get; }
    }
}
