using System.Web.Mvc;

namespace mylist.Areas.Site
{
    public class SiteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Site";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Top",
                "Top/{action}/{id}",
                new { Controller = "Top", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Site_default",
                "Top/{controller}/{action}/{id}",
                new { Controller = "Top", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}