using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface ITicketTypeRepository:IDisposable
    {
        IEnumerable<TicketTypes> GetTicketTypes(int id);
        TicketTypes GetType(int id);
        void InsertType(TicketTypes type);
        void UpdateType(TicketTypes type);
        void DeleteType(int id);
        void Save();
    }
}
