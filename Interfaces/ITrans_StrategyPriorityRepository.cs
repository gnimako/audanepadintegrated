using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_StrategyPriorityRepository
    {
        Trans_StrategyPriority GetRecord (string Id);

        Trans_StrategyPriority GetRecordByMasterStrategyPriorityId (int Id);

		IEnumerable<Trans_StrategyPriority> GetAllRecords();
		Trans_StrategyPriority Add(Trans_StrategyPriority rec);
		Trans_StrategyPriority Update(Trans_StrategyPriority recChanges);
		Trans_StrategyPriority Delete(string id);

         
    }
}