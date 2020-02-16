using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStrategy_PriorityRepository
    {
        Strategy_Priority GetRecord(int Id);

        Strategy_Priority GetRecordByName(string name);
        IEnumerable<Strategy_Priority> GetAllRecords();
        Strategy_Priority Add(Strategy_Priority atype);
        Strategy_Priority Update(Strategy_Priority atypeChanges);
        Strategy_Priority Delete(int id);

         
    }
}