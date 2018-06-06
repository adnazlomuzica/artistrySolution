using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IMaterialRepository:IDisposable
    {
        IEnumerable<Materials> GetMaterials();
        Materials GetMaterial(int materialId);
        void InsertMaterial(Materials material);
        void UpdateMaterial(Materials material);
        void DeleteMaterial(int materialId);
        void Save();
    }
}
