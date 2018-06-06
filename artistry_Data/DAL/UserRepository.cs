using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class UserRepository:IUserRepository, IDisposable
    {
        private Context.Context context;

        public UserRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<UserAccounts> GetUsers(int Id)
        {
            return context.UserAccounts.Where(x => x.Id != Id).OrderBy(x=>x.Username.Trim()).ToList();
        }

        public UserAccounts GetUser(string username, string password = "")
        {
            if (password != "")
            {
                return context.UserAccounts.SingleOrDefault(x => x.Username == username && x.PasswordHash == password && x.Active == true);
            }
            return context.UserAccounts.SingleOrDefault(x => x.Username == username);
        }

        public UserAccounts GetUserById(int Id)
        {
            return context.UserAccounts.Find(Id);
        }

        public void InsertUser(UserAccounts user)
        {
            context.UserAccounts.Add(user);
        }

        public void UpdateUser(UserAccounts user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

       


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
