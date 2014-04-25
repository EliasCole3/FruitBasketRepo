using FruitBasketSimulator.Domain.Users;
using FruitBasketSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FruitBasketSimulator.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult Login(LoginViewModel RUser)
        {
            if (ModelState.IsValid)
            {
                if (RUser.IsValid(RUser.loginUsername, RUser.loginPassword))
                {
                    FormsAuthentication.SetAuthCookie(RUser.loginUsername, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                    TempData["message"] = string.Format("Login data is incorrect");
                }
            }
            return View(RUser);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }







    }
}
