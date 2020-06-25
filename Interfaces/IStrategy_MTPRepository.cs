using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStrategy_MTPRepository
    {
        Strategy_MTP GetRecord(int Id);

        Strategy_MTP GetRecordByName(string name);
        IEnumerable<Strategy_MTP> GetAllRecords();
        Strategy_MTP Add(Strategy_MTP atype);
        Strategy_MTP Update(Strategy_MTP atypeChanges);
        Strategy_MTP Delete(int id);
         
    }
}