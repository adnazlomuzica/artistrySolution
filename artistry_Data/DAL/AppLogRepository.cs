using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class AppLogRepository:IAppLogRepository, IDisposable
    {
        private Context.Context context;

        public AppLogRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<AppLogs> GetAppLogs()
        {
            return context.AppLogs.OrderByDescending(x=>x.Logged).Where(x=>x.Level=="Error" || x.Level=="Fatal").ToList();
        }

        public IEnumerable<AppLogs> GetThisWeeksLogs()
        {
            int startweek = DateTime.Now.AddDays(-6).DayOfYear;
            int endweek = DateTime.Now.DayOfYear;

            return context.AppLogs.OrderBy(x => x.Logged).Where(x => (x.Level == "Error") && (x.Logged.DayOfYear>=startweek && x.Logged.DayOfYear<=endweek)).ToList();
        }

        public IEnumerable<AppLogs> GetLastLogs()
        {
            IEnumerable<AppLogs> logs=context.AppLogs.Where(x => (x.Level == "Error") && x.Seen==false).ToList();
            return logs;
        }

        public int GetNewLogs()
        {
           int logs=context.AppLogs.Where(x => (x.Level == "Error" || x.Level == "Fatal") && x.Seen == false).Count();
           return logs;
        }

        public void InsertAppLog(AppLogs log)
        {
            if (log.Level != "Info")
            {
                context.AppLogs.Add(log);
            }
        }

        public void UpdateAppLogs(AppLogs log)
        {
            context.Entry(log).State = EntityState.Modified;
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
