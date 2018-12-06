using System.Web;
using System.Web.Routing;

namespace CMS.API.Helpers
{
    public class PdfHelper
    {
        public static PdfController Setup()
        {
            RouteData route = new RouteData();
            route.Values.Add("action", "GetPdf");
            route.Values.Add("controller", "Pdf");
            PdfController controller = new PdfController();
            System.Web.Mvc.ControllerContext context = new System.Web.Mvc.ControllerContext(new HttpContextWrapper(HttpContext.Current), route, controller);
            controller.ControllerContext = context;
            return controller;
        }
    }
}