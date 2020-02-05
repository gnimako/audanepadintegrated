using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_RiskCategoryRepository
    {
        LkUp_RiskCategory GetRecord(int Id);

        LkUp_RiskCategory GetRecordByName(string name);
        IEnumerable<LkUp_RiskCategory> GetAllRecords();
        LkUp_RiskCategory Add(LkUp_RiskCategory atype);
        LkUp_RiskCategory Update(LkUp_RiskCategory atypeChanges);
        LkUp_RiskCategory Delete(int id);
        
    }
}