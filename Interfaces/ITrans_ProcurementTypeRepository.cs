using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProcurementTypeRepository
    {

		Trans_ProcurementType GetRecord (string Id);

		Trans_ProcurementType GetRecordByMainRecord_Id (int Id);

		IEnumerable<Trans_ProcurementType> GetAllRecords();
		Trans_ProcurementType Add(Trans_ProcurementType rec);
		Trans_ProcurementType Update(Trans_ProcurementType recChanges);
		Trans_ProcurementType Delete(string id);
         
    }
}