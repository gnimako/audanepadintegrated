using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProjectScopeRepository
    {
        Trans_ProjectScope GetRecord (string Id);

		IEnumerable<Trans_ProjectScope> GetAllRecords();
		Trans_ProjectScope Add(Trans_ProjectScope rec);
		Trans_ProjectScope Update(Trans_ProjectScope recChanges);
		Trans_ProjectScope Delete(string id);
         
    }
}