using FruitBasketSimulator.Domain.Concrete;
using FruitBasketSimulator.Domain.Fruit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FruitBasketSimulator.Domain.Users
{
    public class RegisteredUser
    {
        List<FruitBasket> fruitBasketList = new List<FruitBasket>();


        [Key]
        [HiddenInput(DisplayValue = false)]
        public int RegisteredUserId { get; set; }

        [Required(ErrorMessage = "Please enter a user name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter an access level")]
        public int AccessLevel { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        //public bool IsAdmin { get; set; }  add with model binding changes








        [HiddenInput(DisplayValue = false)]
        public List<FruitBasket> FruitBasketList
        {
            get { return fruitBasketList; }
            set { fruitBasketList = value; }
        }



        public bool IsValid(string username, string password) //had issues with binding, now in LoginViewModel
        {
            DBContext db = new DBContext();

            RegisteredUser temp = new RegisteredUser();

            temp = ((from b in db.RegisteredUserList
                     where b.Username == username
                     select b).FirstOrDefault());

            if (temp != null)
            {
                if (temp.Password == password)  //no encryption lols
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
