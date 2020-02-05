using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_RiskImpactRepository
    {
        LkUp_RiskImpact GetRecord(int Id);

        LkUp_RiskImpact GetRecordByName(string name);
        IEnumerable<LkUp_RiskImpact> GetAllRecords();
        LkUp_RiskImpact Add(LkUp_RiskImpact atype);
        LkUp_RiskImpact Update(LkUp_RiskImpact atypeChanges);
        LkUp_RiskImpact Delete(int id);
        
    }
}