using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;

namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_FiscalYearRepository
    {
		Trans_FiscalYear GetRecord (string Id);

		IEnumerable<Trans_FiscalYear> GetAllRecords();
		Trans_FiscalYear Add(Trans_FiscalYear rec);
		Trans_FiscalYear Update(Trans_FiscalYear recChanges);
		Trans_FiscalYear Delete(string id);
    }
}