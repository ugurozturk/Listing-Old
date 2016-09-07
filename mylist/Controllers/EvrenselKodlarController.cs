using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mylist.Models;
using System.Web.Security;

namespace mylist.Controllers
{
    public class EvrenselKodlarController : Controller
    {
         mylistEntities ent = new mylistEntities();
        // GET: EvrenselKodlar
        public ActionResult Index()
        {
            return View();//Test
        }
        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user userr)
        {
            var veri = (from a in ent.user
                       where ((a.username == userr.username || a.email == userr.email) || (a.username == userr.email || a.email == userr.username)) &&
                       a.password == userr.password select a).FirstOrDefault();

            if (veri == null)
            {
                return View(userr);
            }
            else
            {
                Session["UserName"] = veri.username;
                Session["email"] = veri.email;
                Session["userID"] = veri.user_id;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Register(user userr)
        {
            return View();
        }


        //CRUD Create - Read - Update - Delete

        [HttpPost]
        public JsonResult createlist(list veri)
        {
            try
            {
                ent.list.Add(veri);
                ent.SaveChanges();
                return Json(new { Result = "OK", Record = veri });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult createuser(user veri)
        {
            try
            {
                ent.user.Add(veri);
                ent.SaveChanges();
                return Json(new { Result = "OK", Record = veri });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult createuserlist(user_list veri)
        {
            try
            {
                ent.user_list.Add(veri);
                ent.SaveChanges();
                return Json(new { Result = "OK", Record = veri });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        

        [HttpPost]
        public JsonResult readlist(int? list_id)
        {
            try
            {
                var liste = (from a in ent.list select new { DisplayText = a.list_id, Value= a.name }).ToList();
                return Json(new { Result = "OK", Options = liste });

            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        [HttpPost]
        public JsonResult readuser()
        {
            try
            {
                List<user> liste = (from a in ent.user select a).ToList();
                return Json(new { Result = "OK", Records = liste });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        

        [HttpPost]
        public JsonResult readuserlist(string userr, int? listtype, int? liststatus)
        {
            
            try
            {
                var liste = (from a in ent.user_list
                             where a.user.username == userr && a.list_status_id == liststatus
                             orderby a.list.name
                             select new
                             {
                                 user_list_id = a.user_list_id,
                                 name = a.list.name,
                                 score = a.score,
                                 episode_complete = a.episode_complete,
                                 list_type_id = a.list.list_type_id,
                                 list_status_id = a.list_status_id,
                                 user_tags = a.user_tags
                             }).ToList();
                return Json(new { Result = "OK", Records = liste });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        

        [HttpPost]
        public JsonResult updatelist(list veri)
        {
            try
            {
                list duzenlenen = (from a in ent.list where a.list_id == veri.list_id select a).FirstOrDefault();
                duzenlenen = veri;
                ent.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        [HttpPost]
        public JsonResult updateuser(user veri)
        {
            try
            {
                user duzenlenen = (from a in ent.user where a.user_id == veri.user_id select a).FirstOrDefault();
                duzenlenen = veri;
                ent.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        [HttpPost]
        public JsonResult updateuserlist(user_list veri)
        {
            try
            {
                int? duzenleyen = Convert.ToInt32(Session["userID"].ToString());
                user_list duzenlenen = (from a in ent.user_list where a.user_list_id == veri.user_list_id && a.user_id == duzenleyen select a).FirstOrDefault();
                if (veri.score > 10) { duzenlenen.score = 10; }
                else if (veri.score < 0) { duzenlenen.score = 0; }
                duzenlenen.score = veri.score;
                duzenlenen.list_status_id = veri.list_status_id;
                if (duzenlenen.list_status_id == 2 || duzenlenen.list_status_id == 7 || duzenlenen.list_status_id == 12 || duzenlenen.list_status_id == 15)
                {
                    if(duzenlenen.list.episode != null)
                    duzenlenen.episode_complete = (int)duzenlenen.list.episode;
                }
                duzenlenen.episode_complete = veri.episode_complete;
                duzenlenen.user_tags = veri.user_tags;
                //duzenlenen.list_status_id = veri.list_status_id;
                //duzenlenen = veri;
                ent.SaveChanges();

                

                return Json(new { Result = "OK" });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        

        [HttpPost]
        public JsonResult deletelist(list veri)
        {
            try
            {
                list silincek = (from a in ent.list where a.list_id == veri.list_id select a).FirstOrDefault();
                ent.list.Remove(silincek);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        [HttpPost]
        public JsonResult deleteuser(user veri)
        {
            try
            {
                user silincek = (from a in ent.user where a.user_id == veri.user_id select a).FirstOrDefault();
                ent.user.Remove(silincek);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        [HttpPost]
        public JsonResult deleteuserlist(user_list veri)
        {
            try
            {
                user_list silincek = (from a in ent.user_list where a.user_list_id == veri.user_list_id select a).FirstOrDefault();
                ent.user_list.Remove(silincek);

                return Json(new { Result = "OK" });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }
        }

        
        //list - user - userlist - usertags
        
        [HttpPost]
        public JsonResult turldenUsername(string  allurl)
        {
            string url = Request.UrlReferrer.ToString();
            string username = url.Substring(url.LastIndexOf('/') +1);
            return Json(new { Result = "OK", sonuc = username });
        }

        
        public JsonResult recentAddedList()
        {
            try { 
            int? userid =  Convert.ToInt32(Session["userID"].ToString());

            var veri = (from a in ent.user_list where a.user_id == userid select new { a.list.name, a.list.list_type.type_name}).Take(4).ToList();
            return Json(new { Result = "OK", sonuc = veri });
            }
            catch
            {
                return Json(new { Result = "ERROR" });
            }
        }

        public JsonResult jtabbaglistatusgetir(int? listTypes)
        {
            var liststatus = (from a in ent.user_list_status where a.list_type_id == listTypes select a).ToList().Select(b => new 
            {
                Value = b.user_list_status_id,
                DisplayText = b.status_name
            });

            return Json(new { Result = "OK", Options = liststatus });
            
        }

        public JsonResult baglistatusgetir(int? listTypes)
        {
            var liststatus = (from a in ent.user_list_status where a.list_type_id == listTypes select a).ToList().Select(b => new SelectListItem
            {
                Value = b.user_list_status_id.ToString(),
                Text = b.status_name
            });


            return Json(liststatus);
        }

        static public string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        static public void CopKod()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            
        }

    }
}