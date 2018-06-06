using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class StyleRepository:IStyleRepository, IDisposable
    {
        private Context.Context context;

        public StyleRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Styles> GetStyles()
        {
            return context.Styles.OrderBy(x => x.Name.Trim()).ToList();
        }

        public Styles GetStyle(int styleId)
        {
            return context.Styles.Where(x => x.Id == styleId).SingleOrDefault();
        }

        public void InsertStyle(Styles style)
        {
            context.Styles.Add(style);
        }

        public void UpdateStyle(Styles style)
        {
            context.Entry(style).State = EntityState.Modified;
        }

        public void DeleteStyle(int styleId)
        {
            Styles style = context.Styles.Find(styleId);
            context.Styles.Remove(style);
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
