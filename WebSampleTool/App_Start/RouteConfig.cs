using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSampleTool
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); // có thể dùng route attribute để map

            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "DangNhap", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TrangChinh",
                url: "trang-chinh",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
