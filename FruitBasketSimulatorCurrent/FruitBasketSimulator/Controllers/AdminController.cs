using FruitBasketSimulator.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FruitBasketSimulator.Models;
using FruitBasketSimulator.Domain.Users;

namespace FruitBasketSimulator.Controllers
{
    public class AdminController : Controller
    {
        private IRegisteredUsers repository;

        //overloaded constructor
        public AdminController(IRegisteredUsers repo)
        {
            repository = repo;
        }


        public ViewResult Index()
        {
            return View(repository.RegisteredUsers);
        }


        public ViewResult Edit2(int registeredUserId)
        {
            RegisteredUser registeredUser = repository.RegisteredUsers.FirstOrDefault(p => p.RegisteredUserId == registeredUserId);
            RegisterNewUserVM temp = new RegisterNewUserVM();
            temp.Username = registeredUser.Username;
            temp.Password = registeredUser.Password;
            temp.AccessLevel = registeredUser.AccessLevel;
            return View(temp);
        }


        [HttpPost]
        public ActionResult Edit2(RegisterNewUserVM RUVM)
        {
            RegisteredUser registeredUser2 = repository.RegisteredUsers.FirstOrDefault(p => p.Username == RUVM.Username);

            if (registeredUser2 == null)
            {
                registeredUser2 = new RegisteredUser();
            }

            registeredUser2.Username = RUVM.Username;
            registeredUser2.Password = RUVM.Password;
            registeredUser2.AccessLevel = RUVM.AccessLevel;


            if (ModelState.IsValid)
            {
                repository.SaveRegisteredUser(registeredUser2);
                TempData["message"] = string.Format("{0} has been saved in the db", registeredUser2.Username);
                return RedirectToAction("Index"); //why not return a view like we have been?
            }
            else
            {
                return View(RUVM);
            }
        }


        public ViewResult Create2()
        {
            return View("Edit2", new RegisterNewUserVM());
        }


        [HttpPost]
        public ActionResult Delete(int registeredUserId)
        {
            RegisteredUser deletedRegisteredUser = repository.DeleteRegisteredUser(registeredUserId);
            if (deletedRegisteredUser != null)
            {
                TempData["message"] = string.Format("User: {0} was deleted from the db",
                deletedRegisteredUser.Username);
            }
            return RedirectToAction("Index");
        }























    }
}
