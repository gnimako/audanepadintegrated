using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStrategy_OutputIndicatorsPriorityMappingRepository
    {
        Strategy_OutputIndicatorsPriorityMapping GetRecord(string Id);

        IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecords();
        IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecordsByIndicator (int id);

        IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecordsByKPA (int kpa);

        IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecordsByPriority (int priority);

        Strategy_OutputIndicatorsPriorityMapping GetRecordsByIndicatorPriorityAndKPA (int indicatorid, int priorityid, int kpa);
        Strategy_OutputIndicatorsPriorityMapping Add(Strategy_OutputIndicatorsPriorityMapping atype);
        Strategy_OutputIndicatorsPriorityMapping Update(Strategy_OutputIndicatorsPriorityMapping atypeChanges);
        Strategy_OutputIndicatorsPriorityMapping Delete(string id);
         
    }
}