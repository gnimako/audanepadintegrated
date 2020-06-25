using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProcurementTypeRepository
    {

        LkUp_ProcurementType GetRecord(int Id);

        LkUp_ProcurementType GetRecordByName(string name);
        IEnumerable<LkUp_ProcurementType> GetAllRecords();
        LkUp_ProcurementType Add(LkUp_ProcurementType atype);
        LkUp_ProcurementType Update(LkUp_ProcurementType atypeChanges);
        LkUp_ProcurementType Delete(int id);
         
    }
}