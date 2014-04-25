using FruitBasketSimulator.Domain.Concrete;
using FruitBasketSimulator.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitBasketSimulator.Models
{
    public class LoginViewModel
    {
        public string loginUsername { get; set; }
        public string loginPassword {get; set;}

        public bool IsValid(string username, string password)
        {
            DBContext db = new DBContext();

            RegisteredUser temp = new RegisteredUser();

            temp = ((from b in db.RegisteredUserList
                     where b.Username == username
                     select b).FirstOrDefault());

            if (temp != null)
            {
                if (temp.Password == password)  //no encryption 
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}