using FruitBasketSimulator.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitBasketSimulator.Models
{
    public class RegisteredUserViewModel
    {

        public IEnumerable<RegisteredUser> RegisteredUsers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}