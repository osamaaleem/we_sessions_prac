using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using we_sessions_prac.Models;
using we_sessions_prac.DAL;

namespace we_sessions_prac.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                UserEntity user = new UserEntity();
                if (user.IsValidUser(login))
                {
                    Session["login"] = login;
                    return RedirectToAction("Index", "Employee");
                }
                ViewBag.ErrorMessage = "Invalid Username of Password";
            }
            return View(login);
        }
        [HttpPost]
        public ActionResult SignUp(Register reg)
        {
            UserEntity user = new UserEntity();
            if (ModelState.IsValid)
            {
                if (user.SignUp(reg)>0)
                {
                    return RedirectToAction("Login");
                }
                ViewBag.ErrorMessage = "Username Already Exists";
            }
            return View(reg);
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return RedirectToAction("login");
        }
    }
}