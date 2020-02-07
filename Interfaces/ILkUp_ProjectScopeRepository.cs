using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProjectScopeRepository
    {
        LkUp_ProjectScope GetRecord(int Id);

        LkUp_ProjectScope GetRecordByName(string name);
        IEnumerable<LkUp_ProjectScope> GetAllRecords();
        LkUp_ProjectScope Add(LkUp_ProjectScope atype);
        LkUp_ProjectScope Update(LkUp_ProjectScope atypeChanges);
        LkUp_ProjectScope Delete(int id);
         
    }
}