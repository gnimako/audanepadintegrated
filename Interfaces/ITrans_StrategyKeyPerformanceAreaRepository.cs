using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_StrategyKeyPerformanceAreaRepository
    {
        Trans_StrategyKeyPerformanceArea GetRecord (string Id);

		IEnumerable<Trans_StrategyKeyPerformanceArea> GetAllRecords();
        IEnumerable<Trans_StrategyKeyPerformanceArea> GetAllRecordsByStrategicPriority(string TransStrategicPriority_Id);
		Trans_StrategyKeyPerformanceArea Add(Trans_StrategyKeyPerformanceArea rec);
		Trans_StrategyKeyPerformanceArea Update(Trans_StrategyKeyPerformanceArea recChanges);
		Trans_StrategyKeyPerformanceArea Delete(string id);
         
    }
}