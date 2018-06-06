using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class AdministratorRepository:IAdministratorRepository, IDisposable
    {
        private Context.Context context;

        public AdministratorRepository(Context.Context context)
        {
            this.context = context;
        }

        public Administrators GetAdministrator(int userId)
        {
            return context.Administrators.Include(x => x.User).Where(x => x.UserId == userId).SingleOrDefault();
        }

        public void UpdateAdmin(Administrators admin)
        {
            context.Entry(admin).State = EntityState.Modified;
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
