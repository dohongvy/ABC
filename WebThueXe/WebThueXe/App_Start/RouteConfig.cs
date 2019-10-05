using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebThueXe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Chi tiết Xe",
                url: "Car/Detail/{metatitle}/{id}",
                defaults: new { controller = "Car", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "WebThueXe.Controllers" }
                );
            routes.MapRoute(
               name: "Chi tiết hóa đơn",
               url: "Car/OrderDetail/{metatitle}/{id}",
               defaults: new { controller = "Car", action = "OrderDetail", id = UrlParameter.Optional },
               namespaces: new[] { "WebThueXe.Controllers" }
               );
            routes.MapRoute(
              name: "Chi tiết tin tức",
              url: "Content/Detail/{metatitle}-{id}",
              defaults: new { controller = "Content", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "WebThueXe.Controllers" }
              );
            routes.MapRoute(
                name: "Về chúng tôi",
                url: "About",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebThueXe.Controllers" }
                );
            routes.MapRoute(
                name: "Trở thành đối tác",
                url: "AgencyRegister",
                defaults: new { controller = "Agency", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "WebThueXe.Controllers" }
                );
            routes.MapRoute(
               name: "Tìm xe",
               url: "FindCar",
               defaults: new { controller = "FindCar", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebThueXe.Controllers" }
               );
            routes.MapRoute(
              name: "Chính Sách",
              url: "Policy",
              defaults: new { controller = "Policy", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "WebThueXe.Controllers" }
              );
            routes.MapRoute(
              name: "Tin tức",
              url: "Content",
              defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "WebThueXe.Controllers" }
              );
            routes.MapRoute(
              name: "Liên Hệ",
              url: "Contact",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "WebThueXe.Controllers" }
              );
            routes.MapRoute(
              name: "Đăng nhập",
              url: "Login",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "WebThueXe.Controllers" }
              );
            routes.MapRoute(
              name: "Đăng ký",
              url: "Register",
              defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
              namespaces: new[] { "WebThueXe.Controllers" }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new[] { "WebThueXe.Controllers" }
            );    

        }
    }
}
