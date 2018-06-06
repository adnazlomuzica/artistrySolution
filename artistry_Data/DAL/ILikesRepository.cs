using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface ILikesRepository:IDisposable
    {
        int GetLikes(int id);
    }
}
