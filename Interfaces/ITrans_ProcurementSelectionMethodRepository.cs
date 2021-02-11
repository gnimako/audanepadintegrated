using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProcurementSelectionMethodRepository
    {
        Trans_ProcurementSelectionMethod GetRecord (string Id);

        IEnumerable<Trans_ProcurementSelectionMethod> GetAllRecords();
        Trans_ProcurementSelectionMethod Add(Trans_ProcurementSelectionMethod rec);
        Trans_ProcurementSelectionMethod Update(Trans_ProcurementSelectionMethod recChanges);
        Trans_ProcurementSelectionMethod Delete(string id);
         
    }
}