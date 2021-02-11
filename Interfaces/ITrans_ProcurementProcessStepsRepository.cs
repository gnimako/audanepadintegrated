using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProcurementProcessStepsRepository
    {
        Trans_ProcurementProcessSteps GetRecord (string Id);

        IEnumerable<Trans_ProcurementProcessSteps> GetAllRecords();

        IEnumerable<Trans_ProcurementProcessSteps> GetAllRecordsByType(string recid);
        Trans_ProcurementProcessSteps Add(Trans_ProcurementProcessSteps rec);
        Trans_ProcurementProcessSteps Update(Trans_ProcurementProcessSteps recChanges);
        Trans_ProcurementProcessSteps Delete(string id);
         
    }
}