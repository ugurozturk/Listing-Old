using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mylist.Models;

namespace mylist.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        mylistEntities ent = new mylistEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listUsers()
        {
            return View();
        }

        public JsonResult getUserGroupOptions()
        {
            try
            {
                var groups = from a in ent.user_group select new { Value = a.user_group_id, DisplayText = a.group_name }; //  _repository.CityRepository.GetAllCities().Select(c => new { DisplayText = c.CityName, Value = c.CityId });
                return Json(new { Result = "OK", Options = groups });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult jListUsers(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            var veri = (from a in ent.user orderby a.user_id descending select new { a.user_id, a.username, a.email, a.registerdate, a.aktif,a.user_group_id }).ToList();
            return Json(new { Result = "OK", Records = veri.Skip(jtStartIndex).Take(jtPageSize), TotalRecordCount = veri.Count});
        }
        public JsonResult jUpdateUser(user User)
        {
            try { 
            user kullanici = (from a in ent.user where a.user_id == User.user_id select a).FirstOrDefault();
            kullanici.username = User.username;
            kullanici.email = User.email;
            if (!(User.password == null || User.password == ""))
            {
                kullanici.password = User.password;
            }
            kullanici.aktif = User.aktif;
            ent.SaveChanges();
            return Json(new { Result = "OK", Record = User });
            }
            catch(Exception ex) { return Json(new { Result = "ERROR",Message = ex.Message }); }
            
        }
        public JsonResult jDelUser(user User)
        {
            try { 
            user kullanici = (from a in ent.user where a.user_id == User.user_id select a).FirstOrDefault();
            ent.user.Remove(kullanici); 
            ent.SaveChanges();
            return Json(new { Result = "OK", Record = User });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR",Message = ex.Message });
            }
            
        }
        public JsonResult jCreateUser(user User)
        {
            try { 
            ent.user.Add(User);
            ent.SaveChanges();
            return Json(new { Result = "OK", Record = User });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
            
        }

        public ActionResult List()
        {
            return View();
        }

        public JsonResult getListTypeOptions()
        {
            try
            {
                var groups = from a in ent.list_type select new { Value = a.list_type_id, DisplayText = a.type_name }; //  _repository.CityRepository.GetAllCities().Select(c => new { DisplayText = c.CityName, Value = c.CityId });
                return Json(new { Result = "OK", Options = groups });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult jListList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            var veri = (from a in ent.list orderby a.list_id descending select new { a.list_id, a.name, a.list_type_id, a.release_date, a.aktif, a.episode }).ToList();
            return Json(new { Result = "OK", Records = veri.Skip(jtStartIndex).Take(jtPageSize), TotalRecordCount = veri.Count });
        }
        public JsonResult jUpdateList(list List)
        {
            try
            {
                list liste = (from a in ent.list where a.list_id == List.list_id select a).FirstOrDefault();
                
                liste.name = List.name;
                liste.episode = List.episode;
                liste.release_date = List.release_date;
                liste.aktif = List.aktif;
                liste.list_type_id = List.list_type_id;

                ent.SaveChanges();
                return Json(new { Result = "OK", Record = List });
            }
            catch (Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message }); }

        }
        public JsonResult jDelList(user User)
        {
            try
            {
                user kullanici = (from a in ent.user where a.user_id == User.user_id select a).FirstOrDefault();
                ent.user.Remove(kullanici);
                ent.SaveChanges();
                return Json(new { Result = "OK", Record = User });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }

        }
        public JsonResult jCreateList(user User)
        {
            try
            {
                ent.user.Add(User);
                ent.SaveChanges();
                return Json(new { Result = "OK", Record = User });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Logs()
        {
            return View();
        }

        public JsonResult listLogs(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try { 
            var veri = (from a in ent.logs orderby a.log_id descending select new { a.log_id, a.log_type.log_type_name, a.info,a.createdDate }).ToList();
            return Json(new { Result = "OK", Records = veri.Skip(jtStartIndex).Take(jtPageSize), TotalRecordCount = veri.Count });
            }
            catch(Exception ex) { return Json(new { Result = "ERROR", Message = ex.Message}); }
        }
    }
}