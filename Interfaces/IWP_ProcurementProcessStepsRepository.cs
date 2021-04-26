using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementProcessStepsRepository
    {
        WP_ProcurementProcessSteps GetRecord (string Id);

        WP_ProcurementProcessSteps GetRecordByProcurementIdStepId1OrStepId2 (string recid, int stepid1, int stepid2);
        WP_ProcurementProcessSteps GetRecordByProcurementIdStepId (string recid, int stepid);
        WP_ProcurementProcessSteps GetRecordByProcurementIdStepNumber (string recid, int stepnumber);
        IEnumerable<WP_ProcurementProcessSteps> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_ProcurementProcessSteps> GetRecordsByProcurementId (string recid);

        IEnumerable<WP_ProcurementProcessSteps> GetAllRecords();

    
        WP_ProcurementProcessSteps Add(WP_ProcurementProcessSteps rec);
        WP_ProcurementProcessSteps Update(WP_ProcurementProcessSteps recChanges);
        WP_ProcurementProcessSteps Delete(string id);
         
    }
}