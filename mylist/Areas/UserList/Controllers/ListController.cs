using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mylist.Areas.UserList.Models;
using mylist.Models;

namespace mylist.Areas.UserList.Controllers
{
    public class ListController : Controller
    {
        // GET: UserList/List
        mylistEntities ent = new mylistEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Animes(string username, string searchText)
        {
            @ViewBag.Tur = "animes";
            @ViewBag.username = username;
            if (searchText != null)
            {
                return View("Index", addListSearch(searchText));
            }
            return View("Index");
        }

        public ActionResult TvSeries(string username, string searchText)
        {
            @ViewBag.Tur = "tvseries";
            @ViewBag.username = username;
            if (searchText != null)
            {
                return View("Index", addListSearch(searchText));
            }
            return View("Index");
        }

        public ActionResult Movies(string username, string searchText)
        {
            @ViewBag.Tur = "movies";
            @ViewBag.username = username;
            if (searchText != null)
            {
                return View("Index", addListSearch(searchText));
            }
            return View("Index");
        }

        public ActionResult Games(string username, string urunaraTxt)
        {
            @ViewBag.Tur = "games";
            @ViewBag.username = username;
            if (urunaraTxt != null)
            {
                return View("Index", addListSearch(urunaraTxt));
            }
            return View("Index");
        }

        public JsonResult addListSearch(string searchvalue)
        {
            try { 
            string sesuser = Session["UserName"].ToString();
            if (sesuser == null) { return Json(new { Result = "ERROR" }); }
            //TODO session tanımlayıp, buton'a tıklanma fonksiyonuna konulacak. Burada ki ile orada ki karşılaştırılıp buton dan mı istek gelmiş diye gözlenecek.
            var veri = (from a in ent.list where a.name.Contains(searchvalue) orderby a.name select new { a.list_id, a.name, a.list_type_id, a.episode, a.aktif }).Take(20).ToList();

            return Json(veri);
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        public ActionResult addList()
        {
            ViewBag.listTypes = (from a in ent.list_type select a).ToList().Select(b => new SelectListItem{
                Value = b.list_type_id.ToString(),
                Text = b.type_name
            });

            ViewBag.liststatus = (from a in ent.user_list_status select a).ToList().Select(b => new SelectListItem
            {
                Value = b.user_list_status_id.ToString(),
                Text = b.status_name,
            });
           

            return View();
        }

        [HttpPost]
        public ActionResult addList(string seriestitle, int listTypes, int? episode,string datepicker, string addlistcheck,int? liststatus)
        {
            if (Session["userID"] == null) { return View("Index"); }
            try
            {
                DateTime tarih;
                bool tarihceviri = DateTime.TryParse(datepicker, System.Globalization.CultureInfo.CurrentUICulture, System.Globalization.DateTimeStyles.None, out tarih);


                ViewBag.listTypes = (from a in ent.list_type select a).ToList().Select(b => new SelectListItem
                {
                    Value = b.list_type_id.ToString(),
                    Text = b.type_name
                });

                ViewBag.liststatus = (from a in ent.user_list_status select a).ToList().Select(b => new SelectListItem
                {
                    Value = b.user_list_status_id.ToString(),
                    Text = b.status_name
                });

                list liste = new list();
                liste.name = seriestitle;
                liste.list_type_id = listTypes;
                liste.episode = episode;
                if (tarihceviri)
                {
                    liste.release_date = tarih;
                }
                liste.aktif = false;
                ent.list.Add(liste);
                ent.SaveChanges();

                int userID = Convert.ToInt32(Session["userID"].ToString());
                int lastlistid = (from a in ent.list orderby a.list_id descending select a.list_id).FirstOrDefault();
                if (addlistcheck == "on")
                {
                    user_list userlist = new user_list();
                    userlist.user_id = userID;
                    userlist.list_id = lastlistid;
                    userlist.list_status_id = (int)liststatus;
                    userlist.addeddate = DateTime.Now;
                    ent.user_list.Add(userlist);
                    ent.SaveChanges();
                }

                logs log = new logs();
                log.log_type_id = 2;
                log.createdDate = DateTime.Now;
                log.info = "user: " + userID + " list: " + lastlistid;
                ent.logs.Add(log);
                ent.SaveChanges();


                ViewBag.sonuc = "Added.";
                return View();
            }
            catch { ViewBag.sonuc = "Something wrong. Try again."; return View(); }
        }

        
        public JsonResult addtomylist(int? listid, int? statusid, int? score, int? epseen)
        {
            try
            {
                int? userid = Convert.ToInt32(Session["userID"].ToString());

                var control = (from a in ent.user_list where a.user_id == userid && a.list_id == listid select a).FirstOrDefault();

                if (control != null)
                {
                    return Json(new { Result = "ERROR", Message = "Already added." });
                }


                if (score < 0) { score = 0; }
                else if (score > 10) { score = 10; }

                user_list userlst = new user_list();
                userlst.user_id = (int)userid;
                userlst.list_id = (int)listid;
                userlst.list_status_id = (int)statusid;
                userlst.score = score;
                if (epseen == null)
                {
                    userlst.episode_complete = 0;
                }
                else
                {
                    userlst.episode_complete = (int)epseen;
                }
                userlst.addeddate = DateTime.Now;
                ent.user_list.Add(userlst);
                ent.SaveChanges();


                return Json(new { Result = "OK", Message = "Recorded" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = "Something happened bad. Tell it to us, for now (mail@uozturk.com) Error Detail : " + ex.Message });
            }
        }
    }
}