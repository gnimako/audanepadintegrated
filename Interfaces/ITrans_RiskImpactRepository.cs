using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_RiskImpactRepository
    {
        Trans_RiskImpact GetRecord (string Id);

		IEnumerable<Trans_RiskImpact> GetAllRecords();
		Trans_RiskImpact Add(Trans_RiskImpact rec);
		Trans_RiskImpact Update(Trans_RiskImpact recChanges);
		Trans_RiskImpact Delete(string id);
         
    }
}