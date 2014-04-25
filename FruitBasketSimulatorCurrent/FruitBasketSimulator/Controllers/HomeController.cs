using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FruitBasketSimulator.Domain.Abstract;
using FruitBasketSimulator.Domain.Concrete;
using FruitBasketSimulator.Domain.Users;
using FruitBasketSimulator.Domain.Fruit;
using FruitBasketSimulator.Models;
using FruitBasketSimulator.HtmlHelpers;
using System.Web.Mvc.Html;


namespace FruitBasketSimulator.Controllers
{
    public class HomeController : Controller
    {
        IRegisteredUsers RegisteredUserRepo;
        IFruitBaskets FruitBasketRepo;
        public int PageSize = 4;

        //Constructor for setup
        public HomeController()
        {

            RegisteredUserRepo = new RegisteredUserRepo();

            FruitBasketRepo = new FruitBasketRepo();
        }

        public HomeController(MockRegisteredUserRepo mockRegisteredUserRepo, MockFruitBasketRepo mockFruitBasketRepo)
        {

            RegisteredUserRepo =  mockRegisteredUserRepo;
 
            FruitBasketRepo = mockFruitBasketRepo;
        }






        public ActionResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RegisterNewUser()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegisterNewUser(RegisterNewUserVM RUserParam)
        {
            RegisteredUser temp = new RegisteredUser();
            temp.Username = RUserParam.Username;
            temp.Password = RUserParam.Password;
            temp.AccessLevel = RUserParam.AccessLevel;

            RegisteredUserRepo.AddUser(temp);
            return View("ShowNewUser", temp);
        }

        public ViewResult ShowNewUser()
        {
            return View();
        }

        public ViewResult ListRegisteredUsers(int page = 1)
        {
            RegisteredUserViewModel model = new RegisteredUserViewModel
            {
                RegisteredUsers = RegisteredUserRepo.RegisteredUsers
                .OrderBy(p => p.RegisteredUserId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = RegisteredUserRepo.RegisteredUsers.Count()
                }
            };
            return View(model);
        }

        public ViewResult ShowExampleFruitBasket()
        {
            FruitBasket temp = new FruitBasket();
            temp.AppleList.Add(new Apple() { AppleId = 1, Color = "Red", Type = "Delicious" });
            temp.AppleList.Add(new Apple() { AppleId = 2, Color = "Blue", Type = "SortaDelicious" });
            temp.AppleList.Add(new Apple() { AppleId = 3, Color = "Green", Type = "VeryDelicious" });
            temp.BananaList.Add(new Banana() { BananaId = 1, Color = "Yellow", NumberOfSpots = 6 });
            temp.GrapesList.Add(new Grapes() { GrapesId = 1, Color = "purple" });
            temp.KiwiList.Add(new Kiwi() { KiwiId = 1, Type = "Saanichton 12" });
            temp.KiwiList.Add(new Kiwi() { KiwiId = 2, Type = "Saanichton 12" });
            temp.MelonList.Add(new Melon() { MelonId = 1, Color = "orange", Type = "cantalope" });
            temp.OrangeList.Add(new Orange() { OrangeId = 1, Color = "orange", Type = "Blood" });

            return View("ShowNewFruitBasket", temp);
        }

        public ViewResult ShowNewFruitBasket()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CreateFruitBasket()
        {
            if (Request.IsAuthenticated == false)
            {
                TempData["message"] = string.Format("You need to Login to Access this feature");
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        public ViewResult CreateFruitBasket(FruitBasketViewModel FBVM)
        {
            FruitBasket temp = FruitBasketRepo.GetFruitBasket(FBVM.FruitBasketId);

            if(FBVM.Apple != null && FBVM.Apple.AppleId != 0)
                temp.AppleList.Add(FBVM.Apple);

            if (FBVM.Banana != null && FBVM.Banana.BananaId != 0)
                temp.BananaList.Add(FBVM.Banana);

            if (FBVM.Grapes != null && FBVM.Grapes.GrapesId != 0)
                temp.GrapesList.Add(FBVM.Grapes);

            if (FBVM.Kiwi != null && FBVM.Kiwi.KiwiId != 0)
                temp.KiwiList.Add(FBVM.Kiwi);

            if (FBVM.Melon != null && FBVM.Melon.MelonId != 0)
                temp.MelonList.Add(FBVM.Melon);

            if (FBVM.Orange != null && FBVM.Orange.OrangeId != 0)
                temp.OrangeList.Add(FBVM.Orange);

            FruitBasketRepo.SaveFruitBasket2(temp);

            return View("ShowNewFruitBasket", temp);
        }

        [HttpGet]
        public ViewResult NewEdit1()
        {
            if (Request.IsAuthenticated == false)
            {
                TempData["message"] = string.Format("You need to Login to Access this feature");
                return View("Index");
            }
            return View();
        }

        [HttpPost]
        public ViewResult NewEdit1(NewEditVM1 vm1)
        {
            //look up fruit basket with id
            bool FruitBasketExists = FruitBasketRepo.FruitBasketExists(vm1.LookupID);

            //If fruit basket doesn't exist, prompt user to create new FB(redirect to get view with error message)
            if (FruitBasketExists == false)
            {
                TempData["message"] = string.Format("The Fruit Basket specified by that ID does not exist.");
                return View("NewEdit1");
            }
            //If fruit basket does exist, look it up 
            else 
            {
               FruitBasket temp = FruitBasketRepo.GetFruitBasket(vm1.LookupID);
               //and return it with the edit2 view
               return View("NewEdit2", temp);
            }

            
        }

        [HttpGet]
        public ViewResult NewEdit2()
        {
            if (Request.IsAuthenticated == false)
            {
                TempData["message"] = string.Format("You need to Login to Access this feature");
                return View("Index");
            }
            return View();
        }

        //[HttpPost]
        //public ViewResult NewEdit2(FruitBasket FB)
        //{
        //}
        



    }
}
