using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IStrategy_KeyPerformanceAreaRepository
    {
        Strategy_KeyPerformanceArea GetRecord(int Id);

        Strategy_KeyPerformanceArea GetRecordByName(string name);
        IEnumerable<Strategy_KeyPerformanceArea> GetAllRecords();

        IEnumerable<Strategy_KeyPerformanceArea> GetAllRecordsByStrategicPriority(int StrategicPriority_Id);
        Strategy_KeyPerformanceArea Add(Strategy_KeyPerformanceArea atype);
        Strategy_KeyPerformanceArea Update(Strategy_KeyPerformanceArea atypeChanges);
        Strategy_KeyPerformanceArea Delete(int id);
         
    }
}