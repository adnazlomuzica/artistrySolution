using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ClientRepository:IClientRepository, IDisposable
    {
        private Context.Context context;

        public int GetRegClients()
        {
            return context.Clients.Count();
        }

        public int GetRegClientsMonth()
        {
            return context.Clients.Include(x => x.User).Where(x => x.User.RegistrationDate.Month == DateTime.Now.Month).Count();
        }

        public ClientRepository(Context.Context context)
        {
            this.context = context;
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
