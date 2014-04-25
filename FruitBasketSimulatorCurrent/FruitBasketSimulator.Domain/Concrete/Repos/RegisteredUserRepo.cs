using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Abstract;
using FruitBasketSimulator.Domain.Users;

namespace FruitBasketSimulator.Domain.Concrete
{
    public class RegisteredUserRepo : IRegisteredUsers
    {
        private DBContext db = new DBContext();

       public IQueryable<RegisteredUser> RegisteredUsers 
        {
           
            get 
            {
                //var db = new DBContext();
                return db.RegisteredUserList; 
            }
            set {/*not implemented*/}
        }

        public void AddUser(RegisteredUser user)
        {
            //var db = new DBContext();
            db.RegisteredUserList.Add(user);
            db.SaveChanges();
        }

        public void RemoveUser(int registeredUserId)
        {
            //var db = new DBContext();
            db.RegisteredUserList.Remove((from b in db.RegisteredUserList
                                          where b.RegisteredUserId == registeredUserId
                                          select b).FirstOrDefault());
            db.SaveChanges();
        }

        public RegisteredUser GetUser(int registeredUserId)
        {
            //var db = new DBContext();
            RegisteredUser temp = new RegisteredUser();
            temp = ((from b in db.RegisteredUserList
                         where b.RegisteredUserId == registeredUserId
                         select b).FirstOrDefault());
            return temp;
        }

        public List<RegisteredUser> GetAllUsers()
        {
            //var db = new DBContext();
            List<RegisteredUser> temp = (db.RegisteredUserList).ToList();
            return temp;
        }


        public void SaveRegisteredUser(RegisteredUser registeredUser)
        {
            if (registeredUser.RegisteredUserId == 0)
            {
                db.RegisteredUserList.Add(registeredUser);
            }
            else
            {
                RegisteredUser dbEntry = db.RegisteredUserList.Find(registeredUser.RegisteredUserId);
                if (dbEntry != null)
                {
                    dbEntry.Username = registeredUser.Username;
                    dbEntry.AccessLevel = registeredUser.AccessLevel;
                    dbEntry.Password = registeredUser.Password;
                    dbEntry.FruitBasketList = registeredUser.FruitBasketList;
                }
            }
            db.SaveChanges();
        }

        public RegisteredUser DeleteRegisteredUser(int registeredUserId)
        {
            RegisteredUser dbEntry = db.RegisteredUserList.Find(registeredUserId);
            if (dbEntry != null)
            {
                db.RegisteredUserList.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
