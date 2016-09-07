using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mylist.Models;


namespace mylist.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
                var veri = (from a in ent.user
                            where (a.username == userr.email || a.email == userr.email) &&
                            a.password == userr.password
                            select a).FirstOrDefault();

                if (veri == null)
                {
                    return View(userr);
                }
                else
                {
                    if (veri.aktif == false)
                    {
                        ViewBag.error = "This user isn't active or banned. If you think something is wrong, Contact with mods.";
                        return View(userr);
                    }
                    Session["UserName"] = veri.username;
                    Session["email"] = veri.email;
                    Session["userID"] = veri.user_id;
                    Session["userGroup"] = veri.user_group_id;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                ViewBag.error = "This user isn't active or banned. If you think something is wrong, Contact with mods.";
                return View(userr);
            }
        }
    }
}