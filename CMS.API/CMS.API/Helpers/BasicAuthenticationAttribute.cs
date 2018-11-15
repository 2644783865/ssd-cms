using System;
using System.Text;

namespace CMS.API.Helpers
{
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                try
                {
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                    string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                    string username = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                    string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

                    if (username.Equals(AppSettings.BasicAPIUsername) 
                        && password.Equals(AppSettings.BasicAPIPassword)) base.OnActionExecuting(actionContext);
                    else actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
                catch
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}