using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IUserRepository:IDisposable
    {
        IEnumerable<UserAccounts> GetUsers(int Id);
        UserAccounts GetUser(string username, string password="");
        UserAccounts GetUserById(int Id);
        void InsertUser(UserAccounts user);
        void UpdateUser(UserAccounts user);
        void Save();
    }
}
