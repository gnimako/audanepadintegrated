using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_StrategyMTPRepository
    {
        Trans_StrategyMTP GetRecord (string Id);

		IEnumerable<Trans_StrategyMTP> GetAllRecords();
		Trans_StrategyMTP Add(Trans_StrategyMTP rec);
		Trans_StrategyMTP Update(Trans_StrategyMTP recChanges);
		Trans_StrategyMTP Delete(string id);
         
    }
}