using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IAppLogRepository : IDisposable
    {
        IEnumerable<AppLogs> GetAppLogs();
        IEnumerable<AppLogs> GetLastLogs();
        IEnumerable<AppLogs> GetThisWeeksLogs();
        int GetNewLogs();
        void InsertAppLog(AppLogs log);
        void UpdateAppLogs(AppLogs log);
        void Save();
    }
}
