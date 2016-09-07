using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mylist.Models;
using mylist.Controllers;

namespace mylist.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        mylistEntities ent = new mylistEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user userr)
        {
            try
            {
                //kontrol
                
                if (userr.username.Length < 4 || userr.username.Length > 12)
                {
                    ViewBag.error = "Username length must be in 4 and 12";
                    return View(userr);
                }
                if (userr.password.Length < 5 || userr.password.Length > 16)
                {
                    ViewBag.error = "Username length must be in 5 and 16";
                    return View(userr);
                }
                var checkusername = (from a in ent.user where a.username == userr.username select a).FirstOrDefault();
                if (checkusername != null)
                {
                    ViewBag.error = "Error. This username already in use.";
                    return View(userr);
                }
                var checkemail = (from a in ent.user where a.email == userr.email select a).FirstOrDefault();
                if (checkemail != null)
                {
                    ViewBag.error = "Error. This email already in use.";
                    return View(userr);
                }
                //end kontrol
            
            user usr = new user();
            usr.username = userr.username;
            usr.email = userr.email;
            usr.password = userr.password;
            usr.aktif = true;
            usr.age = userr.age;
            usr.user_group_id = 2;
            usr.registerdate = DateTime.Now;
            ent.user.Add(usr);
            ent.SaveChanges();

            logs log = new logs();
            log.createdDate = DateTime.Now;
            log.info = EvrenselKodlarController.GetIPAddress();
            log.log_type_id = 3;
                
            ent.logs.Add(log);

            ent.SaveChanges();

            ViewBag.success = "Register successful.";
            
            return View(userr);
            }
            catch
            {
                ViewBag.error = "Something happaned wrong. Contact with mods.";
                return View(userr);
            }
        }
    }
}