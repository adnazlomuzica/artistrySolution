using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IClientRepository:IDisposable
    {
        int GetRegClients();
        int GetRegClientsMonth();
    }
}
