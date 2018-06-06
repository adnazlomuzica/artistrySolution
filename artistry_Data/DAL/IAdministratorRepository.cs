using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IAdministratorRepository:IDisposable
    {
        Administrators GetAdministrator(int userId);
        void UpdateAdmin(Administrators admin);
        void Save();
    }
}
