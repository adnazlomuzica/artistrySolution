using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IStyleRepository:IDisposable
    {
        IEnumerable<Styles> GetStyles();
        Styles GetStyle(int styleId);
        void InsertStyle(Styles style);
        void UpdateStyle(Styles style);
        void DeleteStyle(int styleId);
        void Save();
    }
}
