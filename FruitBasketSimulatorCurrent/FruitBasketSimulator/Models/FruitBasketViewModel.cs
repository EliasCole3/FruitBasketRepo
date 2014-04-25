using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FruitBasketSimulator.Domain.Fruit;

namespace FruitBasketSimulator.Models
{
    public class FruitBasketViewModel
    {
        public Apple Apple { get; set; }
        public Banana Banana { get; set; }
        public Grapes Grapes { get; set; }
        public Kiwi Kiwi { get; set; }
        public Melon Melon { get; set; }
        public Orange Orange { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public int FruitBasketId { get; set; }
    }
}