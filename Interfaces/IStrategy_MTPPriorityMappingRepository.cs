using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStrategy_MTPPriorityMappingRepository
    {
        Strategy_MTPPriorityMapping GetRecord(string Id);

        IEnumerable<Strategy_MTPPriorityMapping> GetAllRecords();
        IEnumerable<Strategy_MTPPriorityMapping> GetAllRecordsByMTP (int id);

        Strategy_MTPPriorityMapping GetRecordsByMTPAndPriority (int mtpid, int priorityid);
        Strategy_MTPPriorityMapping Add(Strategy_MTPPriorityMapping atype);
        Strategy_MTPPriorityMapping Update(Strategy_MTPPriorityMapping atypeChanges);
        Strategy_MTPPriorityMapping Delete(string id);
         
    }
}