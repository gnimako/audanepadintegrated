using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_RiskRTimeframeRepository
    {
        Trans_RiskRTimeframe GetRecord (string Id);

		IEnumerable<Trans_RiskRTimeframe> GetAllRecords();
		Trans_RiskRTimeframe Add(Trans_RiskRTimeframe rec);
		Trans_RiskRTimeframe Update(Trans_RiskRTimeframe recChanges);
		Trans_RiskRTimeframe Delete(string id);
         
    }
}