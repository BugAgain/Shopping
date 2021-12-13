using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net;

namespace Shopping.Filters
{
    public class IpAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var svc = filterContext.HttpContext.RequestServices;
            var _configuration = svc.GetService(typeof(IConfiguration)) as IConfiguration;

            string ip = filterContext.HttpContext.Connection.LocalIpAddress.ToString();
            string ips = _configuration["BlockedIPs"];

            if (ips.Split(',').Contains(ip))
            {
                filterContext.Result = new ContentResult { Content = "Blocked!" };
                // see 409 - http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                
            }
        }
    }
}
