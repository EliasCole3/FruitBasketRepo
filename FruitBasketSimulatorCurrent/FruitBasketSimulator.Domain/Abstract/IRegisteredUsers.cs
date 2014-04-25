using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasketSimulator.Domain.Users;

namespace FruitBasketSimulator.Domain.Abstract
{
    public interface IRegisteredUsers
    {
        IQueryable<RegisteredUser> RegisteredUsers { get; set; } //for page 188/170

        void AddUser(RegisteredUser user);
        void RemoveUser(int registeredUserId);
        RegisteredUser GetUser(int registeredUserId);
        List<RegisteredUser> GetAllUsers();

        //chapter 10
        void SaveRegisteredUser(RegisteredUser registeredUser);
        RegisteredUser DeleteRegisteredUser(int registeredUserId);
    }
}
