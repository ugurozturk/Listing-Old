using System.Web.Mvc;

namespace mylist.Areas.UserPage
{
    public class UserPageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserPage",
                "UserPage/{username}",
                new { controller = "MyPage", action = "Index", username = UrlParameter.Optional }
            );


            context.MapRoute(
                "UserPage_default",
                "UserPage/{controller}/{action}/{id}",
                new { controller = "MyPage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}