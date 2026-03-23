using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVCLAB6.Controllers
{
    public class AccountController : Controller
    {
        private SchoolDBLAB6Entities db = new SchoolDBLAB6Entities();   

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.tblUsers.FirstOrDefault(u => u.Username == username && u.Password == password);  // ← dùng tblUsers (số nhiều)

            if (user != null)
            {
                Session["LoggedInUser"] = user.Username;
                Session["UserID"] = user.UserID;
                return RedirectToAction("Index", "Departments");
            }

            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
