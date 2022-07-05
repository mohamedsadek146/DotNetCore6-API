using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore6.API.Controllers;
using DotNetCore6.Helpers;
using DotNetCore6.Services.Helpers;
using DotNetCore6.ViewModels.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DotNetCore6.API.Controllers.Shared
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UploadController : BaseController
    {

        [HttpPost]
        public async Task<IEnumerable<UploadedFile>> POST()
        {
            return AttachmentHelper.Upload(Constants._TEMP_UPLOAD_PATH);
        }
   
    
    }
}