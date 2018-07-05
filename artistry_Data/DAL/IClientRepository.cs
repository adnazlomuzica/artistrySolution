using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IClientRepository:IDisposable
    {
        Clients GetClientByUserId(int id);
        int GetRegClients();
        int GetRegClientsMonth();
        void InsertClient(Clients client);
        void Save();
    }
}
