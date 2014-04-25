using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using FruitBasketSimulator.Domain.Abstract;
using FruitBasketSimulator.Domain.Users;
using Moq;
using FruitBasketSimulator.Domain.Concrete;

namespace FruitBasketSimulator.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            //Mock<IRegisteredUsers> mock = new Mock<IRegisteredUsers>();
            //mock.Setup(m => m.RegisteredUsers).Returns(new List<RegisteredUser> {
            //    new RegisteredUser { RegisteredUserId = 1, Username = "testRUserName1", Password="testRUserPass1", AccessLevel=1 },
            //    new RegisteredUser { RegisteredUserId = 2, Username = "testRUserName2", Password="testRUserPass2", AccessLevel=2},
            //    new RegisteredUser { RegisteredUserId = 3, Username = "testRUserName3", Password="testRUserPass3", AccessLevel=3 }
            //    }.AsQueryable());

            //ninjectKernel.Bind<IRegisteredUsers>().ToConstant(mock.Object);
            //replaced with code from 200/182
            ninjectKernel.Bind<IRegisteredUsers>().To<RegisteredUserRepo>();

        }
    }
}