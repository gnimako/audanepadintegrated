using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProcurementLTimeRepository
    {
        LkUp_ProcurementLTime GetRecord(int Id);

        LkUp_ProcurementLTime GetRecordByName(string name);
        IEnumerable<LkUp_ProcurementLTime> GetAllRecords();
        LkUp_ProcurementLTime Add(LkUp_ProcurementLTime atype);
        LkUp_ProcurementLTime Update(LkUp_ProcurementLTime atypeChanges);
        LkUp_ProcurementLTime Delete(int id);
         
    }
}