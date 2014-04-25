using System;
using System.Collections.Generic;
using System.Data.Entity; //DbContext
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Fruit;
using FruitBasketSimulator.Domain.Users;

namespace FruitBasketSimulator.Domain.Concrete
{
    public class DBContext : DbContext
    {

        public DbSet<RegisteredUser> RegisteredUserList { get; set; }

        public DbSet<FruitBasket> FruitBasketList { get; set; }
    }
}
