using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore6.Helpers
{
    public static class HttpRequestHelper
    {
        public static HttpContext Current => new HttpContextAccessor().HttpContext;
        public static string DoIt()
        {
            string Protocol = Current.Request.Protocol;
            return Protocol;
        }
        public static bool IsHeaderContainsKey(string key)
        {
            return Current.Request?.Headers?.Any(header => header.Key.ToLower() == key.ToLower() && !string.IsNullOrEmpty(header.Value)) ?? false;
        }
        public static string GetHeaderValue(string key)
        {
            try
            {
                StringValues header;
                if (Current != null)
                {
                    Current.Request.Headers.TryGetValue(key.ToLower(), out header);
                    return header.ToString();
                }
                else
                    return "";

            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static async System.Threading.Tasks.Task<bool> CallGetRequestAsync(string url)
        {
            HttpClient client = new HttpClient();
            var responseString = client.GetStringAsync(url).ConfigureAwait(true).GetAwaiter();
            return true;
        }
        public static bool CallPostRequest(string url, object viewModel)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonInString = JsonConvert.SerializeObject(viewModel);

                client.PostAsync(url, new StringContent(jsonInString, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
            }
            return true;

        }

        public static bool IsLocal(this HttpRequestMessage request)
        {
            try
            {
                var isLocal = request.Properties["MS_IsLocal"] as Lazy<bool>;
                return isLocal != null && isLocal.Value;
            }
            catch
            {
                return false;
            }

        }
        public static string GetBaseAddress()
        {
            HttpContext request = new HttpContextAccessor().HttpContext;
            var address = string.Format("{0}://{1}", request.Request.Scheme, request.Request.Host);
           return address;
        }


        public static string GetUrl()
        {
            HttpContext context = new HttpContextAccessor().HttpContext;
            string queryString = "";
            try
            {
                queryString = context.Request.QueryString.ToString();
            }
            catch
            {
            }
            return context.Request.Path + queryString;
        }
        public static string GetPath()
        {
            HttpContext context = new HttpContextAccessor().HttpContext;
            return context.Request.Path;
        }
        public static string GetIP()
        {
            HttpContext request = new HttpContextAccessor().HttpContext;
            return request.Connection.RemoteIpAddress.ToString();
        }
        public static string GetUserAgent()
        {
            HttpContext request = new HttpContextAccessor().HttpContext;
            return request.Request.Headers["User-Agent"];
        }

        public static void AddDelayedJob(string url, int seconds)
        {
            string api = GetBaseAddress();
            Task.Delay(seconds * 1000).ContinueWith(t => CallGetRequestAsync($"{api}/{url}")).ConfigureAwait(false);
        }
    }
}
