using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_RiskProbabilityRepository
    {
        Trans_RiskProbability GetRecord (string Id);

		IEnumerable<Trans_RiskProbability> GetAllRecords();
		Trans_RiskProbability Add(Trans_RiskProbability rec);
		Trans_RiskProbability Update(Trans_RiskProbability recChanges);
		Trans_RiskProbability Delete(string id);
         
    }
}