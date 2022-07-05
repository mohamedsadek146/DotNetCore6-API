using DotNetCore6.API.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using DotNetCore6.API.Filters;
using DotNetCore6.Helpers;

namespace DotNetCore6.API.Controllers
{
    [Route("[controller]/[action]")]
    //[ApiController]
    [LanguageFilter]

    public class BaseController : ControllerBase
    {

        public BaseController()
        {
       
        }
      
        
    }
}