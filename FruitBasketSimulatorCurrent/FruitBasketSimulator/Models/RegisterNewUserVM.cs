using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitBasketSimulator.Models
{
    public class RegisterNewUserVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
    }
}