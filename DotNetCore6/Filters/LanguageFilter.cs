using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using DotNetCore6.Helpers;

namespace DotNetCore6.API.Filters
{
    public class LanguageFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string lang = HttpRequestHelper.GetHeaderValue("lang");
            lang = lang.ToLower();
            if (string.IsNullOrEmpty(lang))
                lang = "ar";
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);


        }


    }
}
