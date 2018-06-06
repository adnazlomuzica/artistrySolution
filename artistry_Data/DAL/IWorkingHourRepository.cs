using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IWorkingHourRepository:IDisposable
    {
        IEnumerable<WorkingHours> GetWorkingHours(int id);
        void InsertHours(WorkingHours hours);
        void UpdateHours(WorkingHours hours);
        void Save();
    }
}
