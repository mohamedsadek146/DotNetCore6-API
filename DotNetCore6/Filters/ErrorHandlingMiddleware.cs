using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using DotNetCore6.Services.Exceptions;
using DotNetCore6.Helpers;
using DotNetCore6.Localization.Shared;

using DotNetCore6.ViewModels.Shared;

namespace DotNetCore6.API.Filters
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._logger = logger;
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            var exceptionData = ex.Data;
            bool isAuthorized = true;
            //if (exceptionData.Count > 0 && exceptionData.Contains("code"))
            //{
            //    int exceptionCode = int.Parse(exceptionData["code"].ToString());
            //    if (exceptionCode == 401)
            //        isAuthorized = false;
            //}
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            code = HttpStatusCode.OK;
            //if (ex is BusinessLogicException)
            //    code = HttpStatusCode.OK;

            // _logger.(message, exception);
            var result = JsonConvert.SerializeObject(new ResponseViewModel<object>(null, Resource.ErrorOccurred, false, isAuthorized));
            if (ex is BusinessLogicException || ex is Services.Exceptions.BusinessLogicException)
            {
                _logger.LogWarning(ex, ex.Message);
                if (ex is AuthorizedException || ex is AuthenticatedException)
                {
                    result = JsonConvert.SerializeObject(new ResponseViewModel<object>(null, ex.Message, false, false));
                }
                else
                    result = JsonConvert.SerializeObject(new ResponseViewModel<object>(null, ex.Message, false, isAuthorized));
            }
            else
            {
                _logger.LogError(ex, ex.Message);
            }
            
            try
            {
                Task.Run(() =>
                {
                    //EmailHelper.SendMail("mohamed.sadek146@gmail.com", ex.Message, ex.ToString());
                });
                //EmailHelper.SendMail("mohamed.sadek146@gmail.com", ex.Message, ex.ToString());
            }
            catch (Exception exception)
            {

            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
