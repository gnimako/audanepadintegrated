using System;
using System.Collections.Generic;
using AUDANEPAD_Integrated.Models;


namespace AUDANEPAD_Integrated.Interfaces
{
    public interface ITrans_IndicatorTypeRepository
    {
        Trans_IndicatorType GetRecord (string Id);

		IEnumerable<Trans_IndicatorType> GetAllRecords();
		Trans_IndicatorType Add(Trans_IndicatorType rec);
		Trans_IndicatorType Update(Trans_IndicatorType recChanges);
		Trans_IndicatorType Delete(string id);
         
    }
}