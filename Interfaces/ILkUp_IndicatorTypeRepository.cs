using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_IndicatorTypeRepository
    {
        LkUp_IndicatorType GetRecord(int Id);

        LkUp_IndicatorType GetRecordByName(string name);
        IEnumerable<LkUp_IndicatorType> GetAllRecords();
        LkUp_IndicatorType Add(LkUp_IndicatorType atype);
        LkUp_IndicatorType Update(LkUp_IndicatorType atypeChanges);
        LkUp_IndicatorType Delete(int id);
         
    }
}