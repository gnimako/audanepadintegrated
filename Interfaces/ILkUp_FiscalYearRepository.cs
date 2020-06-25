using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_FiscalYearRepository
    {
        LkUp_FiscalYear GetRecord(int Id);

        LkUp_FiscalYear GetRecordByName(string name);
        IEnumerable<LkUp_FiscalYear> GetAllRecords();
        LkUp_FiscalYear Add(LkUp_FiscalYear atype);
        LkUp_FiscalYear Update(LkUp_FiscalYear atypeChanges);
        LkUp_FiscalYear Delete(int id);
         
    }
}