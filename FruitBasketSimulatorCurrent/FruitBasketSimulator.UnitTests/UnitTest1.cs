using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FruitBasketSimulator.Models;
using System.Web.Mvc.Html;
using FruitBasketSimulator.HtmlHelpers;
using FruitBasketSimulator.Domain.Users;
using System.Collections.Generic;
using FruitBasketSimulator.Domain.Concrete;
using FruitBasketSimulator.Controllers;
using FruitBasketSimulator.Domain.Fruit;


namespace FruitBasketSimulator.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>"
            + @"<a class=""selected"" href=""Page2"">2</a>"
            + @"<a href=""Page3"">3</a>");
        }


        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            List<RegisteredUser> tempList = new List<RegisteredUser>() {
            new RegisteredUser {RegisteredUserId = 1, Username = "P1"},
            new RegisteredUser {RegisteredUserId = 2, Username= "P2"},
            new RegisteredUser {RegisteredUserId = 3, Username= "P3"},
            new RegisteredUser {RegisteredUserId = 4, Username= "P4"},
            new RegisteredUser {RegisteredUserId = 5, Username= "P5"}
            };
            MockRegisteredUserRepo tempRepo = new MockRegisteredUserRepo(tempList);

           
            MockFruitBasketRepo temp3 = new MockFruitBasketRepo();

            // Arrange
            HomeController controller = new HomeController(tempRepo, temp3);
            controller.PageSize = 3;

            // Act
            RegisteredUserViewModel result = (RegisteredUserViewModel)controller.ListRegisteredUsers(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        //[TestMethod]
        //public void FruitBasketRepo_FruitBasketExists()
        //{
        //    // Arrange
        //    FruitBasketRepo repoTemp = new FruitBasketRepo();

        //    FruitBasket temp = new FruitBasket();
        //    temp.BananaList.Add(new Banana() { BananaId = 1, Color = "Yellow", NumberOfSpots = 6 });
        //    temp.GrapesList.Add(new Grapes() { GrapesId = 1, Color = "purple" });
        //    temp.KiwiList.Add(new Kiwi() { KiwiId = 1, Type = "Saanichton 12" });
        //    temp.KiwiList.Add(new Kiwi() { KiwiId = 2, Type = "Saanichton 12" });
        //    temp.MelonList.Add(new Melon() { MelonId = 1, Color = "orange", Type = "cantalope" });
        //    temp.OrangeList.Add(new Orange() { OrangeId = 1, Color = "orange", Type = "Blood" });

        //    repoTemp.AddFruitBasket(temp);
        //    int newFBID = temp.FruitBasketId;

  
        //    // Act
        //    bool shouldBeFalse = repoTemp.FruitBasketExists(887918973);
        //    bool shouldBeTrue = repoTemp.FruitBasketExists(newFBID);

        //    // Assert
        //    Assert.AreEqual(shouldBeFalse, false);
        //    Assert.AreEqual(shouldBeTrue, true);
        //}
        

    }
}
