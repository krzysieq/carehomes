using System;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace HAMS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public static class CommonAuthentication
    {
        public static bool Authenticate(System.Web.Http.Controllers.HttpActionContext actionContext, string masterUsername, string masterPassword)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                string username = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

                if (username == masterUsername && password == masterPassword)
                {
                    return true;
                }
            }

            return false;
        }
    }
    public class ClientAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            /*
             * WARNING: These credentials should be changed when deploying to production
             */
            if (CommonAuthentication.Authenticate(actionContext, "client", "4pHkTiyv48xT"))
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }

    public class AdminAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            /*
             * WARNING: These credentials should be changed when deplying to production
             */
            if (CommonAuthentication.Authenticate(actionContext, "admin", "hc3OpgYAHnJC"))
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}
