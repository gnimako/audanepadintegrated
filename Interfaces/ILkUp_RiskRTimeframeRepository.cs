using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_RiskRTimeframeRepository
    {
        LkUp_RiskRTimeframe GetRecord(int Id);

        LkUp_RiskRTimeframe GetRecordByName(string name);
        IEnumerable<LkUp_RiskRTimeframe> GetAllRecords();
        LkUp_RiskRTimeframe Add(LkUp_RiskRTimeframe atype);
        LkUp_RiskRTimeframe Update(LkUp_RiskRTimeframe atypeChanges);
        LkUp_RiskRTimeframe Delete(int id);
        
    }
}