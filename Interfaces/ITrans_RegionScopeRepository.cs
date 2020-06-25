using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_RegionScopeRepository
    {
        Trans_RegionScope GetRecord (string Id);

		IEnumerable<Trans_RegionScope> GetAllRecords();
		Trans_RegionScope Add(Trans_RegionScope rec);
		Trans_RegionScope Update(Trans_RegionScope recChanges);
		Trans_RegionScope Delete(string id);
         
    }
}