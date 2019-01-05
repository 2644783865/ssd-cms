using System.Web.Mvc;
using System.Web.Routing;

namespace CMS.API.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Conferences",
                "Home",
                new { Controller = "Web", action = "Conferences" });

            routes.MapRoute(
                "ConferenceProgram",
                "Conferences/{id}",
                new { Controller = "Web", action = "ConferenceProgram", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Web", action = "Conferences", id = UrlParameter.Optional }
            );
        }
    }
}