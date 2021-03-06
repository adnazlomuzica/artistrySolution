﻿using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface ICountryRepository:IDisposable
    {
        IEnumerable<Countries> GetCountries();
    }
}
