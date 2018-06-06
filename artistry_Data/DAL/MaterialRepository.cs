using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class MaterialRepository:IMaterialRepository, IDisposable
    {
        private Context.Context context;

        public MaterialRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Materials> GetMaterials()
        {
            return context.Materials.OrderBy(x => x.Name.Trim()).ToList();
        }

        public Materials GetMaterial(int materialId)
        {
            return context.Materials.Where(x => x.Id == materialId).SingleOrDefault();
        }

        public void InsertMaterial(Materials material)
        {
            context.Materials.Add(material);
        }

        public void UpdateMaterial(Materials material)
        {
            context.Entry(material).State = EntityState.Modified;
        }

        public void DeleteMaterial(int materialId)
        {
            Materials material = context.Materials.Find(materialId);
            context.Materials.Remove(material);
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
