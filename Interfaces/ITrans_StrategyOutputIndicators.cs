using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    
    public interface ITrans_StrategyOutputIndicators
    {
        Trans_StrategyOutputIndicators GetRecord (string Id);
		IEnumerable<Trans_StrategyOutputIndicators> GetAllRecords();
		Trans_StrategyOutputIndicators Add(Trans_StrategyOutputIndicators rec);
		Trans_StrategyOutputIndicators Update(Trans_StrategyOutputIndicators recChanges);
		Trans_StrategyOutputIndicators Delete(string id);
         
    }
}