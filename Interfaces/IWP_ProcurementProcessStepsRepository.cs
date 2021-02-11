using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface IWP_ProcurementProcessStepsRepository
    {
        WP_ProcurementProcessSteps GetRecord (string Id);
        IEnumerable<WP_ProcurementProcessSteps> GetRecordsByMainRecordId (string recid);
        IEnumerable<WP_ProcurementProcessSteps> GetRecordsByProcurementId (string recid);

        IEnumerable<WP_ProcurementProcessSteps> GetAllRecords();

    
        WP_ProcurementProcessSteps Add(WP_ProcurementProcessSteps rec);
        WP_ProcurementProcessSteps Update(WP_ProcurementProcessSteps recChanges);
        WP_ProcurementProcessSteps Delete(string id);
         
    }
}