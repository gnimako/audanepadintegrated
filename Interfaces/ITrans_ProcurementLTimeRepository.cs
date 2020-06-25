using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_ProcurementLTimeRepository
    {
        Trans_ProcurementLTime GetRecord (string Id);

		IEnumerable<Trans_ProcurementLTime> GetAllRecords();
		Trans_ProcurementLTime Add(Trans_ProcurementLTime rec);
		Trans_ProcurementLTime Update(Trans_ProcurementLTime recChanges);
		Trans_ProcurementLTime Delete(string id);
        
    }
}