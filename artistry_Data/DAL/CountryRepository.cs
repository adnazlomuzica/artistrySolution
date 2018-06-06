using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class CountryRepository:ICountryRepository, IDisposable
    {
        private Context.Context context;

        public CountryRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Countries> GetCountries()
        {
            return context.Countries.OrderBy(x => x.Name.Trim()).ToList();
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
