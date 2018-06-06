using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class CurrencyRepository:ICurrencyRepository, IDisposable
    {
        private Context.Context context;

        public CurrencyRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Currencies> GetCurrencies()
        {
            return context.Currencies.OrderBy(x => x.Currency.Trim()).ToList();
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
