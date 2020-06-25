using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_CountryRepository
    {
        Trans_Country GetTrans_Country (string Id);

		IEnumerable<Trans_Country> GetAllTrans_Country();
        Trans_Country Add(Trans_Country rec);
        Trans_Country Update(Trans_Country recChanges);
        Trans_Country Delete(string id);
         
    }
}