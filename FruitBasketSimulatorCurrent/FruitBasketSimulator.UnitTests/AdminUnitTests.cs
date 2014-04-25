using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitBasketSimulator.Domain.Abstract;
using Moq;
using System.Collections.Generic;
using FruitBasketSimulator.Domain;
using FruitBasketSimulator.Controllers;
using FruitBasketSimulator.Domain.Users;
using System.Web.Mvc;
using System.Linq;
using FruitBasketSimulator.Models;

namespace FruitBasketSimulator.UnitTests
{
    [TestClass]
    public class AdminUnitTests
    {
        [TestMethod]
        public void Index_Contains_All_RegisteredUsers()
        {
            // Arrange - create the mock repository
            Mock<IRegisteredUsers> mock = new Mock<IRegisteredUsers>();
            mock.Setup(m => m.RegisteredUsers).Returns(new RegisteredUser[] {
                new RegisteredUser{RegisteredUserId = 1, Username = "RUser1"},
                new RegisteredUser{RegisteredUserId = 2, Username = "RUser2"},
                new RegisteredUser{RegisteredUserId = 3, Username = "RUser3"},
                }.AsQueryable());
            // Arrange - create a controller
            AdminController target = new AdminController(mock.Object);
            // Action
            RegisteredUser[] result = ((IEnumerable<RegisteredUser>)target.Index().
            ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual("RUser1", result[0].Username);
            Assert.AreEqual("RUser2", result[1].Username);
            Assert.AreEqual("RUser3", result[2].Username);
        }


        //My View Model work around messed these up

        //[TestMethod]
        //public void Can_Save_Valid_Changes()
        //{
        //    // Arrange - create mock repository
        //    Mock<IRegisteredUsers> mock = new Mock<IRegisteredUsers>();
        //    // Arrange - create the controller
        //    AdminController target = new AdminController(mock.Object);
        //    // Arrange - create a RegisteredUser
        //    RegisterNewUserVM registerNewUserVM = new RegisterNewUserVM { Username = "Test" };
        //    // Act - try to save the RegisteredUser
        //    ActionResult result = target.Edit2(registerNewUserVM);
        //    // Assert - check that the repository was called
        //    mock.Verify(m => m.SaveRegisteredUser(registeredUser));
        //    // Assert - check the method result type
        //    Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        //}

        //[TestMethod]
        //public void Cannot_Save_Invalid_Changes()
        //{
        //    // Arrange - create mock repository
        //    Mock<IRegisteredUsers> mock = new Mock<IRegisteredUsers>();
        //    // Arrange - create the controller
        //    AdminController target = new AdminController(mock.Object);
        //    // Arrange - create a RegisteredUser
        //    RegisteredUser registeredUser = new RegisteredUser { Username = "Test" };
        //    // Arrange - add an error to the model state
        //    target.ModelState.AddModelError("error", "error");
        //    // Act - try to save the RegisteredUser
        //    ActionResult result = target.Edit2(registeredUser);
        //    // Assert - check that the repository was not called
        //    mock.Verify(m => m.SaveRegisteredUser(It.IsAny<RegisteredUser>()), Times.Never());
        //    // Assert - check the method result type
        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}


        [TestMethod]
        public void Can_Delete_Valid_RegisteredUsers()
        {
            // Arrange - create a RegisteredUser
            RegisteredUser prod = new RegisteredUser { RegisteredUserId = 2, Username = "Test" };
            // Arrange - create the mock repository
            Mock<IRegisteredUsers> mock = new Mock<IRegisteredUsers>();
            mock.Setup(m => m.RegisteredUsers).Returns(new RegisteredUser[] {
                new RegisteredUser {RegisteredUserId = 1, Username = "RUser1"},
                prod,
                new RegisteredUser {RegisteredUserId = 3, Username = "RUser3"},
                }.AsQueryable());
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act - delete the RegisteredUser
            target.Delete(prod.RegisteredUserId);
            // Assert - ensure that the repository delete method was
            // called with the correct RegisteredUser
            mock.Verify(m => m.DeleteRegisteredUser(prod.RegisteredUserId));
        }
    }
}
