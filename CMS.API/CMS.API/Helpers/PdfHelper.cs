using System.Web;
using System.Web.Routing;

namespace CMS.API.Helpers
{
    public class PdfHelper
    {
        public static PdfController Setup(string viewName)
        {
            RouteData route = new RouteData();
            route.Values.Add("action", viewName);
            route.Values.Add("controller", "Pdf");
            PdfController controller = new PdfController();
            System.Web.Mvc.ControllerContext context = new System.Web.Mvc.ControllerContext(new HttpContextWrapper(HttpContext.Current), route, controller);
            controller.ControllerContext = context;
            return controller;
        }
    }
}