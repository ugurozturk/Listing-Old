using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mylist.Areas.UserPage.Controllers
{
    public class MyPageController : Controller
    {
        // GET: UserPage/MyPage
        
        public ActionResult Index(string username)
        {
            if (username == null)
            {
                username = Session["UserName"].ToString();
            }

            //TODO Altta yazanlar view bag ile geri dönderilip sistemde kullanılacaklar.
            //Kimin Profili
            //Last Online
            //Cinsiyet
            //Birthday
            //Joined
            //Anime istatistikleri
            /* watching
             * Completed
             * On-Hold
             * Dropped
             * Plan to watch
             */
            //Movie istatistikleri
            /* Completed
             * On-Hold
             * Dropped
             * Plan to watch
             */
            //TV Serisi istatistikleri
            /* Watching
             * On-Hold
             * Dropped
             * Completed
             * Plan to watch
             */
            //Oyun istatistikleri
            /* Playing
             * On-Hold
             * Dropped
             * Completed
             * Plan to Play
             */

            return View("Index");
        }


        public ActionResult Test(string username)
        {
            return View();
        }

    }
}