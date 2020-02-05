using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_RiskProbabilityRepository
    {
        LkUp_RiskProbability GetRecord(int Id);

        LkUp_RiskProbability GetRecordByName(string name);
        IEnumerable<LkUp_RiskProbability> GetAllRecords();
        LkUp_RiskProbability Add(LkUp_RiskProbability atype);
        LkUp_RiskProbability Update(LkUp_RiskProbability atypeChanges);
        LkUp_RiskProbability Delete(int id);
        
    }
}