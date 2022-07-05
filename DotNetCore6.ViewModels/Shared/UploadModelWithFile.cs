using Microsoft.AspNetCore.Http;

namespace DotNetCore6.ViewModels.Shared
{
    public class UploadModelWithFile
    {
        public SelectListItemViewModel Data { set; get; }
        public IFormFile File { set; get; }
    }
}
