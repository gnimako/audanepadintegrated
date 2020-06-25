using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_PeriodRepository
    {
        LkUp_Period GetRecord(int Id);

        LkUp_Period GetRecordByName(string name);
        IEnumerable<LkUp_Period> GetAllRecords();
        LkUp_Period Add(LkUp_Period atype);
        LkUp_Period Update(LkUp_Period atypeChanges);
        LkUp_Period Delete(int id);
         
    }
}