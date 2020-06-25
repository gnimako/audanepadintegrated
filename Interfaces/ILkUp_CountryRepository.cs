using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_CountryRepository
    {
        LkUp_Country GetCountry (int Id);

        LkUp_Country GetCountryByName(string name);
		IEnumerable<LkUp_Country> GetAllCountry();
        IEnumerable<LkUp_Country> GetAllAfricanCountry();
        LkUp_Country Add(LkUp_Country rec);
        LkUp_Country Update(LkUp_Country recChanges);
        LkUp_Country Delete(int id);
         
    }
}