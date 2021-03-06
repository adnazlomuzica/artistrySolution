﻿using artistry_Data.Dbo;
using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IMuseumRepository:IDisposable
    {
        List<Museums> GetMuseums();
        List<Museums> GetTop3();
        List<Museums> GetMuseumsByType(int typeId);
        List<Museums> Search(string search);
        Museums GetMuseum(int museumId);
        Museums GetMuseumByAccId(int Id);
        int MuseumsRegistrated();
        int MuseumsRegMonth();
        void InsertMuseum(Museums museum);
        void UpdateMuseum(Museums museum);
        void Save();

        List<MuseumInfoVM> GetShortDescription();

    }
}
