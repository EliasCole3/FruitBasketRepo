using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Abstract;
using FruitBasketSimulator.Domain.Users;

namespace FruitBasketSimulator.Domain.Concrete
{
    public class MockRegisteredUserRepo : IRegisteredUsers
    {
        //Class members
        List<RegisteredUser> registeredUserList = new List<RegisteredUser>();

        //Constructors
        public MockRegisteredUserRepo() { }

        public MockRegisteredUserRepo(List<RegisteredUser> ListOfRegisteredUsers)
        {
            registeredUserList = ListOfRegisteredUsers;
        }


        //Properties
        public List<RegisteredUser> RegisteredUserList
        {
            get
            {
                return registeredUserList;
            }
            set
            {
                registeredUserList = value;
            }
        }

        public IQueryable<RegisteredUser> RegisteredUsers
        {
            get
            //{ return (IQueryable<RegisteredUser>)registeredUserList; }
            { 
                return registeredUserList.AsQueryable<RegisteredUser>(); 
            }
            set
            {

            }
        }

        //Implemmented interface methods
        public void AddUser(RegisteredUser user)
        {
            registeredUserList.Add(user);
        }

        public void RemoveUser(int userId)
        {
            RegisteredUserList.Remove(RegisteredUserList.Find(x => x.RegisteredUserId == userId));
        }

        public RegisteredUser GetUser(int userId)
        {
            return (registeredUserList.Find(x => x.RegisteredUserId == userId));
        }

        public List<RegisteredUser> GetAllUsers()
        {
            return (RegisteredUserList);
        }


        public void SaveRegisteredUser(RegisteredUser registeredUser)
        {
            throw new NotImplementedException();
        }

        public RegisteredUser DeleteRegisteredUser(int registeredUserId)
        {
            throw new NotImplementedException();
        }
    }
}
