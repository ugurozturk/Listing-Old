using System.Web.Mvc;

namespace mylist.Areas.UserList
{
    public class UserListAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserList";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "List",
                "List/{action}/{username}",
                new { controller = "List", username = UrlParameter.Optional }
            );


            context.MapRoute(
                "UserList_default",
                "UserList/{controller}/{action}/{id}",
                new { controller="List", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}