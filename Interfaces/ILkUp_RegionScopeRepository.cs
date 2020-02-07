using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_RegionScopeRepository
    {
        LkUp_RegionScope GetRecord(int Id);

        LkUp_RegionScope GetRecordByName(string name);
        IEnumerable<LkUp_RegionScope> GetAllRecords();
        LkUp_RegionScope Add(LkUp_RegionScope atype);
        LkUp_RegionScope Update(LkUp_RegionScope atypeChanges);
        LkUp_RegionScope Delete(int id);
         
    }
}