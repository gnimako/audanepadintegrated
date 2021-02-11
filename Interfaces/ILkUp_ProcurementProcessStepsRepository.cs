using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProcurementProcessStepsRepository
    {
        LkUp_ProcurementProcessSteps GetRecord(int Id);

        LkUp_ProcurementProcessSteps GetRecordByName(string name);
        IEnumerable<LkUp_ProcurementProcessSteps> GetAllRecords();
        LkUp_ProcurementProcessSteps Add(LkUp_ProcurementProcessSteps rec);
        LkUp_ProcurementProcessSteps Update(LkUp_ProcurementProcessSteps recChanges);
        LkUp_ProcurementProcessSteps Delete(int id);
         
    }
}