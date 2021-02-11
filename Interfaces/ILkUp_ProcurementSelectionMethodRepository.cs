using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ILkUp_ProcurementSelectionMethodRepository
    {
        LkUp_ProcurementSelectionMethod GetRecord(int Id);

        LkUp_ProcurementSelectionMethod GetRecordByName(string name);
        IEnumerable<LkUp_ProcurementSelectionMethod> GetAllRecords();
        LkUp_ProcurementSelectionMethod Add(LkUp_ProcurementSelectionMethod rec);
        LkUp_ProcurementSelectionMethod Update(LkUp_ProcurementSelectionMethod recChanges);
        LkUp_ProcurementSelectionMethod Delete(int id);
         
    }
}