using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FruitBasketSimulator.Domain.Users;


namespace FruitBasketSimulator.Binders
{
    public class RegisteredUserModelBinder : IModelBinder
    {
        private const string sessionKey = "RegisteredUser";
        public object BindModel(ControllerContext controllerContext,
        ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            RegisteredUser rUser = (RegisteredUser)controllerContext.HttpContext.Session[sessionKey];
            // create the Cart if there wasn't one in the session data
            if (rUser == null)
            {
                rUser = new RegisteredUser();
                controllerContext.HttpContext.Session[sessionKey] = rUser;
            }
            // return the cart
            return rUser;
        }
    }
}