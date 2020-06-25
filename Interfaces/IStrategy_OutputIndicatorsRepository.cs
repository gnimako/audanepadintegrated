using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStrategy_OutputIndicatorsRepository
    {
        Strategy_OutputIndicators GetRecord(int Id);

        Strategy_OutputIndicators GetRecordByName(string name);
        IEnumerable<Strategy_OutputIndicators> GetAllRecords();
        Strategy_OutputIndicators Add(Strategy_OutputIndicators atype);
        Strategy_OutputIndicators Update(Strategy_OutputIndicators atypeChanges);
        Strategy_OutputIndicators Delete(int id);
         
    }
}